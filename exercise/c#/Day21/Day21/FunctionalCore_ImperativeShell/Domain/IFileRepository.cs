namespace Day21.FunctionalCore_ImperativeShell.Domain;

public interface IFileRepository
{
    FileContent ReadFile(string filePath);
    void ApplyUpdate(string directory, FileUpdated fileUpdated);
    List<FileContent> ReadDirectory(string directory);
}