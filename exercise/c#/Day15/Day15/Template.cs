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
        var key = $"{documentType.ToLowerInvariant()}-{recordType.ToLowerInvariant()}";
        var templatesByDocumentAndRecordType = TemplateMappings()
            .ToDictionary(t => $"{t.DocumentType.ToString().ToLowerInvariant()}-{t.RecordType.ToString().ToLowerInvariant()}", t => t);
        if (templatesByDocumentAndRecordType.TryGetValue(key, out var template))
        {
            return template;
        }

        var key2 = $"{documentType.ToLowerInvariant()}-{RecordType.All.ToString().ToLowerInvariant()}";
        if (templatesByDocumentAndRecordType.TryGetValue(key2, out var template2))
        {
            return template2;
        }

        throw new ArgumentException("Invalid Document template type or record type");
    }

    public override string ToString()
        => DocumentTemplate.ToString();
}