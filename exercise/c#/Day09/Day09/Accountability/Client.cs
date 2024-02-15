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
            orderLines.Select(FormatLine));

    private static string FormatLine(KeyValuePair<string, double> line)
        => $"{line.Key} for {FormatPrice(line.Value)}";

    private string FormatTotal()
        => $"Total : {FormatPrice(TotalAmount())}";

    private static string FormatPrice(double value)
        => $"{value.ToString(InvariantCulture)}€";

    public double TotalAmount()
        => orderLines.Values.Sum();
}