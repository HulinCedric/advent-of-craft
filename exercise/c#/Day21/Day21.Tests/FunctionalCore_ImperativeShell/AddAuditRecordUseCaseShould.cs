using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class AddAuditRecordUseCaseShould
{
    private const string DirectoryName = "audits";

    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private static readonly ImmutableList<string> NoContent = [];
    private static readonly AddNewVisitor Command = new("Alice", DateTime.Parse("2019-04-06T18:00:00"));

    private readonly AuditManager _auditManager = new(3);
    private readonly Persister _persister = new();

    private readonly AddAuditRecordUseCase _useCase;

    public AddAuditRecordUseCaseShould() =>
        _useCase = new AddAuditRecordUseCase(DirectoryName, _auditManager, _persister);

    [Fact]
    public void Adds_new_visitor_to_a_new_file_because_no_file_today()
    {
        AddRecord();

        _persister.ReadFile(File("audit_1.txt"))
            .Should()
            .BeEquivalentTo(FileContent("audit_1.txt", ContentFrom(NewContent)));
    }

    [Fact]
    public void Append_To_Current_File_When_Current_File_Not_Full()
    {
        _persister.WithAlreadyExistingFile(
            DirectoryName,
            FileContent(
                "audit_1.txt",
                ContentFrom(
                    "Peter;2019-04-06 16:30:00",
                    "Jane;2019-04-06 16:40:00")));

        AddRecord();

        _persister.ReadFile(File("audit_1.txt"))
            .Should()
            .BeEquivalentTo(
                FileContent(
                    "audit_1.txt",
                    ContentFrom(
                        "Peter;2019-04-06 16:30:00",
                        "Jane;2019-04-06 16:40:00",
                        NewContent)));
    }

    [Fact]
    public void A_New_File_Is_Created_When_The_Current_File_Overflows()
    {
        _persister.WithAlreadyExistingFiles(
            DirectoryName,
            Files(
                FileContent("audit_1.txt", NoContent),
                FileContent(
                    "audit_2.txt",
                    ContentFrom(
                        "Peter;2019-04-06 16:30:00",
                        "Jane;2019-04-06 16:40:00",
                        "Jack;2019-04-06 17:00:00"))));

        AddRecord();

        _persister.ReadFile(File("audit_3.txt"))
            .Should()
            .BeEquivalentTo(FileContent("audit_3.txt", ContentFrom(NewContent)));
    }

    private static string File(string fileName) => Path.Combine(DirectoryName, fileName);

    private void AddRecord() => _useCase.Handle(Command);

    private static List<FileContent> Files(params FileContent[] files) => [..files];

    private static FileContent FileContent(string fileName, ImmutableList<string> lines) =>
        new(fileName, lines);

    private static ImmutableList<string> ContentFrom(params string[] content) => [..content];
}