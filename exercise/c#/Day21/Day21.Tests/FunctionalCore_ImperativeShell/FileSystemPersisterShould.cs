using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class FileSystemPersisterShould : IDisposable
{
    private const string DirectoryName = "audits";
    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private static readonly ImmutableList<string> NoContent = [];

    private readonly FileSystemPersister _persister = new();

    public void Dispose()
    {
        if (Directory.Exists(DirectoryName))
        {
            Directory.Delete(DirectoryName, recursive: true);
        }
    }


    [Fact]
    public void ReadDirectory_ReturnsEmptyList_When_NoFiles() =>
        _persister.ReadDirectory(DirectoryName)
            .Should()
            .BeEmpty();

    [Fact]
    public void ReadDirectory_ReturnsFiles_When_FilesExist()
    {
        _persister.WithAlreadyExistingFiles(
            DirectoryName,
            Files(
                FileContent("audit_1.txt", NoContent),
                FileContent("audit_2.txt", ContentFrom(NewContent))));

        _persister.ReadDirectory(DirectoryName)
            .Should()
            .BeEquivalentTo(
                Files(
                    FileContent("audit_1.txt", NoContent),
                    FileContent("audit_2.txt", ContentFrom(NewContent))));
    }

    [Fact]
    public void ReadEmptyFile_When_File_does_not_exist() =>
        _persister.ReadFile(FilePath("audit_1.txt"))
            .Should()
            .BeEquivalentTo(new FileContent("audit_1.txt", NoContent));

    [Fact]
    public void ApplyUpdate_CreatesNewFileWithCorrectContent()
    {
        _persister.WithAlreadyExistingFile(
            DirectoryName,
            new FileContent("audit_1.txt", ContentFrom("Original Content")));

        var fileUpdated = new FileUpdated(
            "audit_1.txt",
            $"Completely{Environment.NewLine}New Content");

        _persister.ApplyUpdate(DirectoryName, fileUpdated);

        _persister.ReadFile(FilePath("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
                new FileContent(
                    "audit_1.txt",
                    ContentFrom("Completely", "New Content")));
    }

    [Fact]
    public void ApplyUpdate_ReplaceFileContent_With_NewContent()
    {
        _persister.WithAlreadyExistingFile(
            DirectoryName,
            new FileContent("audit_1.txt", ContentFrom("Original Content")));

        var fileUpdated = new FileUpdated(
            "audit_1.txt",
            $"Completely{Environment.NewLine}New Content");

        _persister.ApplyUpdate(DirectoryName, fileUpdated);

        _persister.ReadFile(FilePath("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
                new FileContent(
                    "audit_1.txt",
                    ContentFrom("Completely", "New Content")));
    }

    private static List<FileContent> Files(params FileContent[] files) => [..files];

    private static FileContent FileContent(string fileName, ImmutableList<string> lines) =>
        new(fileName, lines);

    private static string FilePath(string fileName) => Path.Combine(DirectoryName, fileName);

    private static ImmutableList<string> ContentFrom(params string[] content) => [..content];
}