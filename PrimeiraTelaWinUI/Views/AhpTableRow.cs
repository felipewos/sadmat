namespace PrimeiraTelaWinUI.Views;

public sealed class AhpTableRow
{
	public string Id { get; }

	public string Group { get; }

	public string Weight { get; }

	public AhpTableRow(string id, string group, string weight)
	{
		Id = id;
		Group = group;
		Weight = weight;
	}
}
