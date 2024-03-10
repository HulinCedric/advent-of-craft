namespace Day21.FunctionalCore_ImperativeShell;

public class AuditManager(int maxEntriesPerFile)
{
    public FileUpdated AddRecord(List<FileContent> files, string visitorName, DateTime timeOfVisit) =>
        new("audit_3.txt", "Alice;2019-04-06 18:00:00");
}