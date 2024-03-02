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

    private static IEnumerable<(DocumentType documentType, RecordType recordType)> AllCombinations()
        => from documentType in Enum.GetValues<DocumentType>()
           from recordType in Enum.GetValues<RecordType>()
           select (documentType, recordType);

    private static string FindTemplateSafely(DocumentType documentType, RecordType recordType)
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