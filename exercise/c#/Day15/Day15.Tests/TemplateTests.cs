namespace Day15.Tests;

[UsesVerify]
public class TemplateTests
{
    private static readonly string[] DocumentTypes = Enum.GetNames<DocumentType>();

    private static readonly string[] RecordTypes = Enum.GetNames<RecordType>();


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
        => from documentType in DocumentTypes
           from recordType in RecordTypes
           select (documentType, recordType);

    private static string FindTemplateSafely(string documentType, string recordType)
    {
        try
        {
            return $"{Template.FindTemplateFor(documentType, recordType)}";
        }
        catch (Exception ex)
        {
            return $"{ex.GetType()}: {ex.Message}";
        }
    }
}