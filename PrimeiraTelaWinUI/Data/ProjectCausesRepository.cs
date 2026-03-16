using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace PrimeiraTelaWinUI.Data;

public static class ProjectCausesRepository
{
	private const string CausesJsonFileName = "causas.json";

	private const string CausesCsvFileName = "causas.csv";

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	public static IReadOnlyList<string> LoadCauses(string? projectFolderPath)
	{
		if (string.IsNullOrWhiteSpace(projectFolderPath) || !Directory.Exists(projectFolderPath))
		{
			return Array.Empty<string>();
		}
		string filePath = Path.Combine(projectFolderPath, "causas.json");
		if (!File.Exists(filePath))
		{
			return Array.Empty<string>();
		}
		try
		{
			return Normalize(JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath), JsonOptions) ?? new List<string>());
		}
		catch
		{
			return Array.Empty<string>();
		}
	}

	public static void SaveCauses(string? projectFolderPath, IEnumerable<string> causes)
	{
		if (!string.IsNullOrWhiteSpace(projectFolderPath))
		{
			Directory.CreateDirectory(projectFolderPath);
			List<string> normalizedCauses = Normalize(causes);
			File.WriteAllText(Path.Combine(projectFolderPath, "causas.json"), JsonSerializer.Serialize(normalizedCauses, JsonOptions));
		}
	}

	public static string GetCsvPath(string? projectFolderPath)
	{
		if (!string.IsNullOrWhiteSpace(projectFolderPath))
		{
			return Path.Combine(projectFolderPath, "causas.csv");
		}
		return string.Empty;
	}

	public static void ExportTemplateCsv(string? projectFolderPath, bool overwriteExisting)
	{
		if (!string.IsNullOrWhiteSpace(projectFolderPath))
		{
			Directory.CreateDirectory(projectFolderPath);
			string csvPath = GetCsvPath(projectFolderPath);
			if (!overwriteExisting && File.Exists(csvPath))
			{
				throw new IOException("Arquivo causas.csv já existe.");
			}
			File.WriteAllText(csvPath, "Causa\r\nExemplo de causa", Encoding.UTF8);
		}
	}

	public static void ExportTemplateCsvToFile(string? csvPath, bool overwriteExisting)
	{
		if (string.IsNullOrWhiteSpace(csvPath))
		{
			throw new ArgumentException("Caminho do arquivo inválido.", "csvPath");
		}
		string directoryPath = Path.GetDirectoryName(csvPath);
		if (!string.IsNullOrWhiteSpace(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}
		if (!overwriteExisting && File.Exists(csvPath))
		{
			throw new IOException("Arquivo causas.csv já existe.");
		}
		File.WriteAllText(csvPath, "Causa\r\nExemplo de causa", Encoding.UTF8);
	}

	public static CauseImportResult ImportFromCsv(string? projectFolderPath, IEnumerable<string> existingCauses)
	{
		if (string.IsNullOrWhiteSpace(projectFolderPath))
		{
			return CauseImportResult.Empty;
		}
		return ImportFromCsvFile(GetCsvPath(projectFolderPath), existingCauses);
	}

	public static CauseImportResult ImportFromCsvFile(string? csvPath, IEnumerable<string> existingCauses)
	{
		if (string.IsNullOrWhiteSpace(csvPath) || !File.Exists(csvPath))
		{
			return CauseImportResult.FileNotFound(csvPath ?? string.Empty);
		}
		HashSet<string> existingSet = new HashSet<string>(Normalize(existingCauses), StringComparer.OrdinalIgnoreCase);
		List<string> importedCauses = new List<string>();
		int skippedDuplicates = 0;
		int invalidRows = 0;
		int causeColumnIndex = 0;
		bool headerProcessed = false;
		bool singleCauseColumnHeader = false;
		string[] lines = File.ReadAllLines(csvPath);
		char separator = DetectCsvSeparator(lines);
		for (int i = 0; i < lines.Length; i++)
		{
			string line = lines[i]?.Trim() ?? string.Empty;
			if (string.IsNullOrWhiteSpace(line))
			{
				continue;
			}
			List<string> columns = ParseCsvLine(line, separator);
			TrimTrailingEmptyColumns(columns);
			if (columns.Count == 0)
			{
				continue;
			}
			if (!headerProcessed)
			{
				headerProcessed = true;
				string firstHeader = NormalizeHeader(columns[0]);
				string secondHeader = ((columns.Count > 1) ? NormalizeHeader(columns[1]) : string.Empty);
				bool num = string.Equals(firstHeader, "causa", StringComparison.OrdinalIgnoreCase);
				bool isIdCauseHeader = (string.Equals(firstHeader, "id", StringComparison.OrdinalIgnoreCase) || string.Equals(firstHeader, "numero", StringComparison.OrdinalIgnoreCase)) && string.Equals(secondHeader, "causa", StringComparison.OrdinalIgnoreCase);
				if (num)
				{
					causeColumnIndex = 0;
					singleCauseColumnHeader = columns.Count == 1;
					continue;
				}
				if (isIdCauseHeader)
				{
					causeColumnIndex = 1;
					continue;
				}
			}
			string causeName;
			if (singleCauseColumnHeader && causeColumnIndex == 0 && columns.Count > 1)
			{
				causeName = UnquoteCsvField(line);
			}
			else
			{
				if (causeColumnIndex >= columns.Count)
				{
					invalidRows++;
					continue;
				}
				causeName = columns[causeColumnIndex];
			}
			causeName = causeName.Trim();
			if (string.IsNullOrWhiteSpace(causeName))
			{
				invalidRows++;
			}
			else if (!existingSet.Add(causeName))
			{
				skippedDuplicates++;
			}
			else
			{
				importedCauses.Add(causeName);
			}
		}
		return new CauseImportResult(fileFound: true, csvPath, importedCauses, skippedDuplicates, invalidRows);
	}

	private static List<string> Normalize(IEnumerable<string> values)
	{
		return (from value in values
			where !string.IsNullOrWhiteSpace(value)
			select value.Trim()).Distinct<string>(StringComparer.OrdinalIgnoreCase).ToList();
	}

	private static char DetectCsvSeparator(IEnumerable<string> lines)
	{
		string? source = lines.FirstOrDefault((string line) => !string.IsNullOrWhiteSpace(line)) ?? string.Empty;
		int commas = source.Count((char character) => character == ',');
		if (source.Count((char character) => character == ';') <= commas)
		{
			return ',';
		}
		return ';';
	}

	private static List<string> ParseCsvLine(string line, char separator)
	{
		List<string> columns = new List<string>();
		StringBuilder field = new StringBuilder();
		bool insideQuotes = false;
		for (int i = 0; i < line.Length; i++)
		{
			char current = line[i];
			if (current == '"')
			{
				if (insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
				{
					field.Append('"');
					i++;
				}
				else
				{
					insideQuotes = !insideQuotes;
				}
			}
			else if (current == separator && !insideQuotes)
			{
				columns.Add(field.ToString().Trim());
				field.Clear();
			}
			else
			{
				field.Append(current);
			}
		}
		columns.Add(field.ToString().Trim());
		return columns;
	}

	private static void TrimTrailingEmptyColumns(List<string> columns)
	{
		int i = columns.Count - 1;
		while (i >= 0 && string.IsNullOrWhiteSpace(columns[i]))
		{
			columns.RemoveAt(i);
			i--;
		}
	}

	private static string NormalizeHeader(string value)
	{
		return UnquoteCsvField(value).Trim().TrimStart('\ufeff').Replace(" ", string.Empty, StringComparison.Ordinal);
	}

	private static string UnquoteCsvField(string value)
	{
		string trimmed = value.Trim();
		if (trimmed.Length >= 2 && trimmed.StartsWith('"') && trimmed.EndsWith('"'))
		{
			string text = trimmed;
			trimmed = text.Substring(1, text.Length - 1 - 1);
		}
		return trimmed.Replace("\"\"", "\"", StringComparison.Ordinal).Trim();
	}
}
