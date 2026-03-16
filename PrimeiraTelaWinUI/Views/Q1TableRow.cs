namespace PrimeiraTelaWinUI.Views;

public sealed class Q1TableRow
{
	public string Number { get; }

	public string Cause { get; }

	public string Value1 { get; }

	public string Value2 { get; }

	public string Value3 { get; }

	public string Value4 { get; }

	public string Value5 { get; }

	public string Average { get; }

	public string Proportion { get; }

	public string Status { get; }

	public Q1TableRow(string number, string cause, string value1, string value2, string value3, string value4, string value5, string average, string proportion, string status)
	{
		Number = number;
		Cause = cause;
		Value1 = value1;
		Value2 = value2;
		Value3 = value3;
		Value4 = value4;
		Value5 = value5;
		Average = average;
		Proportion = proportion;
		Status = status;
	}
}
