using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrimeiraTelaWinUI.Views;

public sealed class NamedListItem : INotifyPropertyChanged
{
	private string name;

	private int number;

	private readonly string numberPrefix;

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
				OnPropertyChanged("DisplayName");
			}
		}
	}

	public int Number
	{
		get
		{
			return number;
		}
		set
		{
			if (number != value)
			{
				number = value;
				OnPropertyChanged("Number");
				OnPropertyChanged("ItemId");
				OnPropertyChanged("DisplayName");
			}
		}
	}

	public string ItemId
	{
		get
		{
			string numberText = Number.ToString("D2");
			return (string.IsNullOrWhiteSpace(numberPrefix) ? string.Empty : numberPrefix) + numberText;
		}
	}

	public string DisplayName => ItemId + ". " + Name;

	public event PropertyChangedEventHandler? PropertyChanged;

	public NamedListItem(string name, string numberPrefix = "", int number = 0)
	{
		this.name = name;
		this.numberPrefix = numberPrefix.Trim().ToUpperInvariant();
		this.number = number;
	}

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
