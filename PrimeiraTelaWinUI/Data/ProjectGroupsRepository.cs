using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PrimeiraTelaWinUI.Data;

public static class ProjectGroupsRepository
{
	private const string GroupsFileName = "groups.json";

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	public static IReadOnlyList<string> LoadGroups(string? projectFolderPath)
	{
		if (string.IsNullOrWhiteSpace(projectFolderPath) || !Directory.Exists(projectFolderPath))
		{
			return Array.Empty<string>();
		}
		string filePath = Path.Combine(projectFolderPath, "groups.json");
		if (!File.Exists(filePath))
		{
			return Array.Empty<string>();
		}
		try
		{
			return (from groupName in JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath), JsonOptions) ?? new List<string>()
				where !string.IsNullOrWhiteSpace(groupName)
				select groupName.Trim()).Distinct<string>(StringComparer.OrdinalIgnoreCase).ToList();
		}
		catch
		{
			return Array.Empty<string>();
		}
	}

	public static void SaveGroups(string? projectFolderPath, IEnumerable<string> groups)
	{
		if (!string.IsNullOrWhiteSpace(projectFolderPath))
		{
			Directory.CreateDirectory(projectFolderPath);
			List<string> normalizedGroups = (from groupName in groups
				where !string.IsNullOrWhiteSpace(groupName)
				select groupName.Trim()).Distinct<string>(StringComparer.OrdinalIgnoreCase).ToList();
			File.WriteAllText(Path.Combine(projectFolderPath, "groups.json"), JsonSerializer.Serialize(normalizedGroups, JsonOptions));
		}
	}
}
