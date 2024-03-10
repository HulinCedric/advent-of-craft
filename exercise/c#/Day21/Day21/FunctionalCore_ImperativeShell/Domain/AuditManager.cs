namespace Day21.FunctionalCore_ImperativeShell.Domain;

public class AuditManager(int maxEntriesPerFile)
{
    public FileUpdated AddRecord(List<FileContent> files, string visitorName, DateTime timeOfVisit)
    {
        var sortedFiles = SortByIndex(files);
        var newRecord = CreateNewRecord(visitorName, timeOfVisit);

        return sortedFiles.Count == 0
                   ? CreateNewFile(sortedFiles, newRecord)
                   : CreateNewFileOrUpdate(sortedFiles, newRecord);
    }

    private static List<FileContent> SortByIndex(List<FileContent> files) =>
        files
            .OrderBy(x => x.FileName)
            .ToList();

    private static string CreateNewRecord(string visitorName, DateTime timeOfVisit) =>
        visitorName + ';' + timeOfVisit.ToString("yyyy-MM-dd HH:mm:ss");

    private static FileUpdated CreateNewFile(List<FileContent> sortedFiles, string newRecord)
    {
        var currentFileIndex = sortedFiles.Count;
        var newFileName = CreateAuditFileName(currentFileIndex + 1);

        return new FileUpdated(newFileName, newRecord);
    }

    private static string CreateAuditFileName(int newIndex) => $"audit_{newIndex}.txt";

    private FileUpdated CreateNewFileOrUpdate(List<FileContent> sortedFiles, string newRecord)
    {
        var currentFile = sortedFiles.Last();
        return CanAppendToFile(currentFile)
                   ? AppendToFile(newRecord, currentFile)
                   : CreateNewFile(sortedFiles, newRecord);
    }
    
    private bool CanAppendToFile(FileContent currentFile) => currentFile.Lines.Count < maxEntriesPerFile;

    private static FileUpdated AppendToFile(string newRecord, FileContent currentFile)
    {
        var newContent = currentFile.Lines.Append(newRecord);
        return new FileUpdated(currentFile.FileName, string.Join(Environment.NewLine, newContent));
    }
}