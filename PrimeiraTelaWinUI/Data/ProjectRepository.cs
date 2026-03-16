using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using PrimeiraTelaWinUI.Views;

namespace PrimeiraTelaWinUI.Data;

public static class ProjectRepository
{
	private sealed class StoredProject
	{
		public string Name { get; set; } = string.Empty;

		public string Course { get; set; } = string.Empty;

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset ModifiedAt { get; set; }

		public string FolderPath { get; set; } = string.Empty;
	}

	private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
	{
		WriteIndented = true
	};

	public static IReadOnlyList<ProjectItem> LoadProjects()
	{
		string filePath = ProjectStorage.ProjectsFilePath;
		if (!File.Exists(filePath))
		{
			return Array.Empty<ProjectItem>();
		}
		try
		{
			return (from item in JsonSerializer.Deserialize<List<StoredProject>>(File.ReadAllText(filePath), JsonOptions) ?? new List<StoredProject>()
				where !string.IsNullOrWhiteSpace(item.Name)
				select new ProjectItem(item.Name.Trim(), item.Course?.Trim() ?? string.Empty, item.CreatedAt, item.ModifiedAt, item.FolderPath)).ToList();
		}
		catch
		{
			return Array.Empty<ProjectItem>();
		}
	}

	public static void SaveProjects(IEnumerable<ProjectItem> projects)
	{
		string projectsFilePath = ProjectStorage.ProjectsFilePath;
		string directoryPath = Path.GetDirectoryName(projectsFilePath);
		if (!string.IsNullOrWhiteSpace(directoryPath))
		{
			Directory.CreateDirectory(directoryPath);
		}
		string json = JsonSerializer.Serialize(projects.Select((ProjectItem project) => new StoredProject
		{
			Name = project.Name,
			Course = project.Course,
			CreatedAt = project.CreatedAt,
			ModifiedAt = project.ModifiedAt,
			FolderPath = project.FolderPath
		}).ToList(), JsonOptions);
		File.WriteAllText(projectsFilePath, json);
	}
}
