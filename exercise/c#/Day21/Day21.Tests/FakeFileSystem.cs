namespace Day21.Tests;

public class FakeFileSystem : IFileSystem
{
    public string[] GetFiles(string directoryName) => [];

    public void WriteAllText(string filePath, string content)
    {
    }

    public IEnumerable<string> ReadAllLines(string filePath) => new[] { "Alice;2019-04-06 18:00:00" };
}