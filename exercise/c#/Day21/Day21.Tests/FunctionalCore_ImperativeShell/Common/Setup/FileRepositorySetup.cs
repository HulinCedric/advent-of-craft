using Day21.FunctionalCore_ImperativeShell.Domain;

namespace Day21.Tests.FunctionalCore_ImperativeShell.Common.Setup;

public static class FileRepositorySetup
{
    public static void AlreadyContains(this IFileRepository repository, string directory, FileContent file)
    {
        var content = string.Join(Environment.NewLine, file.Lines);
        repository.ApplyUpdate(directory, new FileUpdated(file.FileName, content));
    }

    public static void AlreadyContains(
        this IFileRepository repository,
        string directoryName,
        List<FileContent> files)
    {
        foreach (var file in files)
        {
            repository.AlreadyContains(directoryName, file);
        }
    }
}