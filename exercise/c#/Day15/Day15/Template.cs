namespace Day15;

public record Template(
    DocumentTemplate DocumentTemplate,
    RecordType RecordType,
    DocumentType DocumentType)
{
    private static IEnumerable<Template> TemplateMappings()
        => new[]
        {
            new Template(DocumentTemplate.DEERPP, RecordType.IndividualProspect, DocumentType.DEER),
            new Template(DocumentTemplate.DEERPM, RecordType.LegalProspect, DocumentType.DEER),
            new Template(DocumentTemplate.AUTP, RecordType.IndividualProspect, DocumentType.AUTP),
            new Template(DocumentTemplate.AUTM, RecordType.LegalProspect, DocumentType.AUTM),
            new Template(DocumentTemplate.SPEC, RecordType.All, DocumentType.SPEC),
            new Template(DocumentTemplate.GLPP, RecordType.IndividualProspect, DocumentType.GLPP),
            new Template(DocumentTemplate.GLPM, RecordType.LegalProspect, DocumentType.GLPM)
        };

    public static Template FindTemplateFor(string documentType, string recordType)
    {
        var key = Key(documentType, recordType);
        var templatesByDocumentAndRecordType = TemplateMappings()
            .ToDictionary(t => Key(t.DocumentType.ToString(), t.RecordType.ToString()), t => t);
        if (templatesByDocumentAndRecordType.TryGetValue(key, out var template))
        {
            return template;
        }

        var key2 = Key(documentType, RecordType.All.ToString());
        if (templatesByDocumentAndRecordType.TryGetValue(key2, out var template2))
        {
            return template2;
        }

        throw new ArgumentException("Invalid Document template type or record type");
    }

    private static string Key(string documentType, string recordType)
        => $"{documentType.ToLowerInvariant()}-{recordType.ToLowerInvariant()}";

    public override string ToString()
        => DocumentTemplate.ToString();
}