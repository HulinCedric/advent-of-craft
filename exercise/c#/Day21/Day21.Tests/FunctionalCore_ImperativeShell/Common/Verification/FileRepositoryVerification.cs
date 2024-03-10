using Day21.FunctionalCore_ImperativeShell.Domain;
using FluentAssertions;

namespace Day21.Tests.FunctionalCore_ImperativeShell.Common.Verification;

public static class FileRepositoryVerification
{
    public static void ShouldContains(
        this IFileRepository persister,
        string directoryName,
        FileContent file) =>
        persister.ReadFile(FilePath(directoryName, file.FileName))
            .Should()
            .BeEquivalentTo(file);

    public static void ShouldContains(
        this IFileRepository persister,
        string directoryName,
        IEnumerable<FileContent> files) =>
        persister.ReadDirectory(directoryName)
            .Should()
            .BeEquivalentTo(files);

    private static string FilePath(string directoryName, string fileName) =>
        Path.Combine(directoryName, fileName);
}