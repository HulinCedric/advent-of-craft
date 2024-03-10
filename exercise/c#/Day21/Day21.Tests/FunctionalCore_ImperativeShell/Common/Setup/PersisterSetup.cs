using Day21.FunctionalCore_ImperativeShell;

namespace Day21.Tests.FunctionalCore_ImperativeShell.Common.Setup;

public static class PersisterSetup
{
    public static void WithAlreadyExistingFile(this IPersistFile persister, string directory, FileContent file)
    {
        var content = string.Join(Environment.NewLine, file.Lines);
        persister.ApplyUpdate(directory, new FileUpdated(file.FileName, content));
    }

    public static void WithAlreadyExistingFiles(
        this IPersistFile persister,
        string directoryName,
        List<FileContent> files)
    {
        foreach (var file in files)
        {
            persister.WithAlreadyExistingFile(directoryName, file);
        }
    }
}