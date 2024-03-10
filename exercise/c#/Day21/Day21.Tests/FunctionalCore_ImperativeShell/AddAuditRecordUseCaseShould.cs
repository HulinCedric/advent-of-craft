using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class AddAuditRecordUseCaseShould
{
    private const string DirectoryName = "audits";

    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private static readonly AddNewVisitor Command = new("Alice", DateTime.Parse("2019-04-06T18:00:00"));

    private readonly AuditManager _auditManager = new(3);
    private readonly Persister _persister = new();

    private readonly AddAuditRecordUseCase _useCase;

    public AddAuditRecordUseCaseShould() =>
        _useCase = new AddAuditRecordUseCase(DirectoryName, _auditManager, _persister);

    [Fact]
    public void Adds_new_visitor_to_a_new_file_because_no_file_today()
    {
        _useCase.Handle(Command);

        _persister.ReadFile(FilePath("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
                new FileContent(
                    "audit_1.txt",
                    [
                        NewContent
                    ]));
    }

    [Fact]
    public void Append_To_Current_File_When_Current_File_Not_Full()
    {
        _persister.WithAlreadyExistingFile(
            DirectoryName,
            new FileContent(
                "audit_1.txt",
                [
                    "Peter;2019-04-06 16:30:00",
                    "Jane;2019-04-06 16:40:00"
                ]));

        _useCase.Handle(Command);

        _persister.ReadFile(FilePath("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
                new FileContent(
                    "audit_1.txt",
                    [
                        "Peter;2019-04-06 16:30:00",
                        "Jane;2019-04-06 16:40:00",
                        NewContent
                    ]));
    }

    private static string FilePath(string fileName) => Path.Combine(DirectoryName, fileName);
}

public class Persister
{
    private readonly Dictionary<string, FileContent> _files = new();

    public FileContent ReadFile(string filePath) => _files[filePath];

    public void ApplyUpdate(string directory, FileUpdated fileUpdated)
    {
        var filePath = Path.Combine(directory, fileUpdated.FileName);

        var newFileContent = fileUpdated.NewContent.Split(Environment.NewLine).ToImmutableList();

        _files[filePath] = new FileContent(fileUpdated.FileName, newFileContent);
    }

    public List<FileContent> ReadDirectory(string directory) =>
        _files
            .Where(kvp => Path.GetDirectoryName(kvp.Key) == directory)
            .Select(kvp => kvp.Value)
            .ToList();

    public void WithAlreadyExistingFile(string directory, FileContent fileContent)
    {
        var filePath = Path.Combine(directory, fileContent.FileName);

        _files[filePath] = fileContent;
    }
}

public record AddNewVisitor(string VisitorName, DateTime TimeOfVisit);

public class AddAuditRecordUseCase
{
    private readonly AuditManager _auditManager;
    private readonly string _directory;
    private readonly Persister _persister;

    public AddAuditRecordUseCase(string directory, AuditManager auditManager, Persister persister)
    {
        _auditManager = auditManager;
        _persister = persister;
        _directory = directory;
    }

    public void Handle(AddNewVisitor addNewVisitor)
    {
        var files = _persister.ReadDirectory(_directory);

        var fileUpdated = _auditManager.AddRecord(
            files,
            addNewVisitor.VisitorName,
            addNewVisitor.TimeOfVisit);

        _persister.ApplyUpdate(_directory, fileUpdated);
    }
}