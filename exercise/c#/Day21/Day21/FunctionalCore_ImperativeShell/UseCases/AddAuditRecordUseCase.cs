using Day21.FunctionalCore_ImperativeShell.Domain;

namespace Day21.FunctionalCore_ImperativeShell.UseCases;

public class AddAuditRecordUseCase(
    string directory,
    AuditManager auditManager,
    IFileRepository fileRepository)
{
    public void Handle(AddNewVisitor addNewVisitor)
    {
        var files = fileRepository.ReadDirectory(directory);

        var fileUpdated = auditManager.AddRecord(
            files,
            addNewVisitor.VisitorName,
            addNewVisitor.TimeOfVisit);

        fileRepository.ApplyUpdate(directory, fileUpdated);
    }
}