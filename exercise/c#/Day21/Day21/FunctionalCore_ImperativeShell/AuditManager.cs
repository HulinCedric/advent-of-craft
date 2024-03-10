namespace Day21.FunctionalCore_ImperativeShell;

public class AuditManager(int maxEntriesPerFile)
{
    public FileUpdated AddRecord(List<FileContent> files, string visitorName, DateTime timeOfVisit)
    {
        var sorted = SortByIndex(files);
        var newRecord = visitorName + ';' + timeOfVisit.ToString("yyyy-MM-dd HH:mm:ss");

        if (sorted.Count == 0)
        {
            return new FileUpdated("audit_1.txt", newRecord);
        }

        var currentFile = sorted.Last();
        if (currentFile.Lines.Count < maxEntriesPerFile)
        {
            var newContent = currentFile.Lines.Append(newRecord);
            return new FileUpdated(currentFile.FileName, string.Join(Environment.NewLine, newContent));
        }

        var currentFileIndex = sorted.Count;
        var newIndex = currentFileIndex + 1;
        var newName = $"audit_{newIndex}.txt";

        return new FileUpdated(newName, newRecord);
    }

    private static List<FileContent> SortByIndex(List<FileContent> files) =>
        files
            .OrderBy(x => x.FileName)
            .ToList();
}