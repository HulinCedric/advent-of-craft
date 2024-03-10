namespace Day21.FunctionalCore_ImperativeShell;

public class AddAuditRecordUseCase
{
    private readonly AuditManager _auditManager;
    private readonly string _directory;
    private readonly Persister _persister;

    public AddAuditRecordUseCase(string directory, AuditManager auditManager, Persister persister)
    {
        _auditManager = auditManager;
        _persister = persister;
        _directory = directory;
    }

    public void Handle(AddNewVisitor addNewVisitor)
    {
        var files = _persister.ReadDirectory(_directory);

        var fileUpdated = _auditManager.AddRecord(
            files,
            addNewVisitor.VisitorName,
            addNewVisitor.TimeOfVisit);

        _persister.ApplyUpdate(_directory, fileUpdated);
    }
}