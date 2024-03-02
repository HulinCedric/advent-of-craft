namespace Day15;

public record Template(DocumentTemplate DocumentTemplate, RecordType RecordType, DocumentType DocumentType)
{
    public override string ToString() => DocumentTemplate.ToString();
}