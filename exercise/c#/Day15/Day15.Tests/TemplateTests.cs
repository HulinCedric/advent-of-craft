namespace Day15.Tests;

[UsesVerify]
public class TemplateTests
{
    [Fact]
    public Task VerifyAllCombinations()
        => Verify(
            AllEnumCombinations()
                .Select(t => FindTemplateFor(t.DocumentType, t.RecordType)));

    private static IEnumerable<(DocumentType DocumentType, RecordType RecordType)> AllEnumCombinations()
        => from documentType in Enum.GetValues<DocumentType>()
           from recordType in Enum.GetValues<RecordType>()
           select (documentType, recordType);

    private static string FindTemplateFor(DocumentType documentType, RecordType recordType)
        => $"[{documentType}, {recordType}] => {FindTemplateSafely(documentType, recordType)}";

    private static string FindTemplateSafely(DocumentType documentType, RecordType recordType)
    {
        try
        {
            return $"{Templates.FindTemplateFor(documentType.ToString(), recordType.ToString())}";
        }
        catch (Exception ex)
        {
            return $"{ex.GetType()}: {ex.Message}";
        }
    }
}