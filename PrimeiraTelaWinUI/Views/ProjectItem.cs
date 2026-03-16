using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrimeiraTelaWinUI.Views;

public class ProjectItem : INotifyPropertyChanged
{
	private string name;

	private string course;

	private string folderPath;

	private DateTimeOffset modifiedAt;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (!(name == value))
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public string Course
	{
		get
		{
			return course;
		}
		set
		{
			if (!(course == value))
			{
				course = value;
				OnPropertyChanged("Course");
			}
		}
	}

	public DateTimeOffset CreatedAt { get; }

	public string FolderPath
	{
		get
		{
			return folderPath;
		}
		set
		{
			if (!(folderPath == value))
			{
				folderPath = value;
				OnPropertyChanged("FolderPath");
			}
		}
	}

	public DateTimeOffset ModifiedAt
	{
		get
		{
			return modifiedAt;
		}
		set
		{
			if (!(modifiedAt == value))
			{
				modifiedAt = value;
				OnPropertyChanged("ModifiedAt");
				OnPropertyChanged("ModifiedAtText");
			}
		}
	}

	public string CreatedAtText => CreatedAt.ToString("dd/MM/yyyy HH:mm");

	public string ModifiedAtText => ModifiedAt.ToString("dd/MM/yyyy HH:mm");

	public event PropertyChangedEventHandler? PropertyChanged;

	public ProjectItem(string name, DateTimeOffset createdAt)
		: this(name, string.Empty, createdAt, createdAt, string.Empty)
	{
	}

	public ProjectItem(string name, DateTimeOffset createdAt, DateTimeOffset modifiedAt)
		: this(name, string.Empty, createdAt, modifiedAt, string.Empty)
	{
	}

	public ProjectItem(string name, DateTimeOffset createdAt, DateTimeOffset modifiedAt, string folderPath)
		: this(name, string.Empty, createdAt, modifiedAt, folderPath)
	{
	}

	public ProjectItem(string name, string course, DateTimeOffset createdAt, DateTimeOffset modifiedAt, string folderPath)
	{
		this.name = name;
		this.course = course;
		CreatedAt = createdAt;
		this.modifiedAt = modifiedAt;
		this.folderPath = folderPath;
	}

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
