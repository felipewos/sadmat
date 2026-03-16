using System;
using System.Collections.Generic;

namespace PrimeiraTelaWinUI.Data;

public sealed class CauseImportResult
{
	public static CauseImportResult Empty { get; } = new CauseImportResult(fileFound: false, string.Empty, Array.Empty<string>(), 0, 0);

	public bool FileFound { get; }

	public string CsvPath { get; }

	public IReadOnlyList<string> AddedCauses { get; }

	public int SkippedDuplicates { get; }

	public int InvalidRows { get; }

	public int AddedCount => AddedCauses.Count;

	public static CauseImportResult FileNotFound(string csvPath)
	{
		return new CauseImportResult(fileFound: false, csvPath, Array.Empty<string>(), 0, 0);
	}

	public CauseImportResult(bool fileFound, string csvPath, IReadOnlyList<string> addedCauses, int skippedDuplicates, int invalidRows)
	{
		FileFound = fileFound;
		CsvPath = csvPath;
		AddedCauses = addedCauses;
		SkippedDuplicates = skippedDuplicates;
		InvalidRows = invalidRows;
	}
}
