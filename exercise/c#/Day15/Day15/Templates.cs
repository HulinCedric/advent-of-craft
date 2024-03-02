namespace Day15;

public static class Templates
{
    private static readonly IEnumerable<Template> Registry = new[]
    {
        new Template(DocumentTemplate.DEERPP, RecordType.IndividualProspect, DocumentType.DEER),
        new Template(DocumentTemplate.DEERPM, RecordType.LegalProspect, DocumentType.DEER),
        new Template(DocumentTemplate.AUTP, RecordType.IndividualProspect, DocumentType.AUTP),
        new Template(DocumentTemplate.AUTM, RecordType.LegalProspect, DocumentType.AUTM),
        new Template(DocumentTemplate.SPEC, RecordType.All, DocumentType.SPEC),
        new Template(DocumentTemplate.GLPP, RecordType.IndividualProspect, DocumentType.GLPP),
        new Template(DocumentTemplate.GLPM, RecordType.LegalProspect, DocumentType.GLPM)
    };

    private static Dictionary<string, Template> Mapping()
        => AllTemplates()
            .Union(ExpandTemplatesWithAllRecordType())
            .ToDictionary();

    private static IEnumerable<(string, Template template)> AllTemplates()
        => from template in Registry
           select (Key(template.DocumentType, template.RecordType), template);

    private static IEnumerable<(string, Template template)> ExpandTemplatesWithAllRecordType()
        => from template in Registry
           where template.RecordType is RecordType.All
           from recordType in Enum.GetValues<RecordType>()
           where recordType is not RecordType.All
           select (Key(template.DocumentType, recordType), template);

    public static Template FindTemplateFor(DocumentType documentType, RecordType recordType)
        => Mapping().TryGetValue(Key(documentType, recordType), out var template)
               ? template
               : throw new ArgumentException("Invalid Document template type or record type");

    private static string Key(DocumentType documentType, RecordType recordType)
        => Key(documentType.ToString(), recordType.ToString());

    private static string Key(string documentType, string recordType)
        => documentType.ToLowerInvariant() + "-" + recordType.ToLowerInvariant();
}