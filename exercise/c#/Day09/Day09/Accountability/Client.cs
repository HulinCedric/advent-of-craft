using static System.Environment;
using static System.Globalization.CultureInfo;
using static System.String;

namespace Day09.Accountability;

public class Client(IReadOnlyDictionary<string, double> orderLines)
{
    public string ToStatement()
        => $"{FormatLines()}{NewLine}{FormatTotal()}";

    private string FormatLines()
        => Join(
            NewLine,
            orderLines
                .Select(kvp => FormatLine(kvp.Key, kvp.Value))
                .ToList());

    private static string FormatLine(string name, double value)
        => $"{name} for {FormatPrice(value)}";

    private string FormatTotal()
        => $"Total : {FormatPrice(TotalAmount())}";

    private static string FormatPrice(double value)
        => $"{value.ToString(InvariantCulture)}€";

    public double TotalAmount()
        => orderLines.Values.Sum();
}