namespace Day21.FunctionalCore_ImperativeShell;

public class AuditManager(int maxEntriesPerFile)
{
    public FileUpdated AddRecord(List<FileContent> files, string visitorName, DateTime timeOfVisit)
    {
        var sorted = SortByIndex(files);
        var newRecord = visitorName + ';' + timeOfVisit.ToString("yyyy-MM-dd HH:mm:ss");

        var currentFile = sorted.Last();
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