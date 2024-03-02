namespace Day15
{
    public record Template(
        DocumentTemplate DocumentTemplate,
        RecordType RecordType,
        DocumentType DocumentType)
    {
        private static IEnumerable<Template> TemplateMappings() => new[]
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
            foreach (var dtt in TemplateMappings())
            {
                if (dtt.DocumentType.ToString().Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
                    dtt.RecordType.ToString().Equals(recordType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return dtt;
                }
                else if (dtt.DocumentType.ToString().Equals(documentType, StringComparison.InvariantCultureIgnoreCase) &&
                         dtt.RecordType.ToString() == "All")
                {
                    return dtt;
                }
            }

            throw new ArgumentException("Invalid Document template type or record type");
        }

        public override string ToString() => DocumentTemplate.ToString();
    }
}