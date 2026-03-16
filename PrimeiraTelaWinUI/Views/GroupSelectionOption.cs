using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrimeiraTelaWinUI.Views;

public sealed class GroupSelectionOption : INotifyPropertyChanged
{
	private string groupId;

	private string groupName;

	private bool isSelected;

	public string GroupId
	{
		get
		{
			return groupId;
		}
		set
		{
			if (!(groupId == value))
			{
				groupId = value;
				OnPropertyChanged("GroupId");
				OnPropertyChanged("GroupLabel");
			}
		}
	}

	public string GroupName
	{
		get
		{
			return groupName;
		}
		set
		{
			if (!(groupName == value))
			{
				groupName = value;
				OnPropertyChanged("GroupName");
				OnPropertyChanged("GroupLabel");
			}
		}
	}

	public string GroupLabel => GroupName + " (" + GroupId + ")";

	public bool IsSelected
	{
		get
		{
			return isSelected;
		}
		set
		{
			if (isSelected != value)
			{
				isSelected = value;
				OnPropertyChanged("IsSelected");
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public GroupSelectionOption(string groupId, string groupName, bool isSelected)
	{
		this.groupId = groupId;
		this.groupName = groupName;
		this.isSelected = isSelected;
	}

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
