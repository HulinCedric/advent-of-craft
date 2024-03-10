namespace Day21.FunctionalCore_ImperativeShell;

public class AuditManager(int maxEntriesPerFile)
{
    public FileUpdated AddRecord(List<FileContent> files, string visitorName, DateTime timeOfVisit)
    {
        var sorted = SortByIndex(files);
        var newRecord = CreateNewRecord(visitorName, timeOfVisit);

        return sorted.Count == 0
                   ? new FileUpdated("audit_1.txt", newRecord)
                   : CreateNewFileOrUpdate(sorted, newRecord);
    }

    private static List<FileContent> SortByIndex(List<FileContent> files) =>
        files
            .OrderBy(x => x.FileName)
            .ToList();

    private static string CreateNewRecord(string visitorName, DateTime timeOfVisit) =>
        visitorName + ';' + timeOfVisit.ToString("yyyy-MM-dd HH:mm:ss");

    private FileUpdated CreateNewFileOrUpdate(List<FileContent> sortedFiles, string newRecord)
    {
        var currentFileIndex = sortedFiles.Count;
        var newIndex = currentFileIndex + 1;
        var newName = $"audit_{newIndex}.txt";

        var currentFile = sortedFiles.Last();
        if (currentFile.Lines.Count < maxEntriesPerFile)
        {
            var newContent = currentFile.Lines.Append(newRecord);
            return new FileUpdated(currentFile.FileName, string.Join(Environment.NewLine, newContent));
        }

        return new FileUpdated(newName, newRecord);
    }
}