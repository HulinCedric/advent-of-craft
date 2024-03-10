namespace Day21.FunctionalCore_ImperativeShell;

public interface IPersistFile
{
    FileContent ReadFile(string filePath);
    void ApplyUpdate(string directory, FileUpdated fileUpdated);
    List<FileContent> ReadDirectory(string directory);
}