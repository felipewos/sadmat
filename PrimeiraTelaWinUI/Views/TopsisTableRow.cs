namespace PrimeiraTelaWinUI.Views;

public sealed class TopsisTableRow
{
	public string Id { get; }

	public string Cause { get; }

	public string Rank { get; }

	public TopsisTableRow(string id, string cause, string rank)
	{
		Id = id;
		Cause = cause;
		Rank = rank;
	}
}
