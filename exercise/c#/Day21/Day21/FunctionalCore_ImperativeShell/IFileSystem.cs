namespace Day21.FunctionalCore_ImperativeShell;

public interface IFileSystem
{
    string[] GetFiles(string directoryName);
    void WriteAllText(string filePath, string content);
    IEnumerable<string> ReadAllLines(string filePath);
}