namespace Day15.Tests;

[UsesVerify]
public class TemplateTests
{
    [Fact]
    public Task VerifyAllCombinations()
        => Verify(AllCombinationResults());

    private static IEnumerable<string> AllCombinationResults()
    {
        foreach (var (documentType, recordType) in AllCombinations())
        {
            var result = FindTemplateSafely(documentType, recordType);

            yield return $"[{documentType}, {recordType}] => {result}";
        }
    }

    private static IEnumerable<(string documentType, string recordType)> AllCombinations()
        => from documentType in Enum.GetNames<DocumentType>()
           from recordType in Enum.GetNames<RecordType>()
           select (documentType, recordType);

    private static string FindTemplateSafely(string documentType, string recordType)
    {
        try
        {
            return $"{Templates.FindTemplateFor(documentType, recordType)}";
        }
        catch (Exception ex)
        {
            return $"{ex.GetType()}: {ex.Message}";
        }
    }
}