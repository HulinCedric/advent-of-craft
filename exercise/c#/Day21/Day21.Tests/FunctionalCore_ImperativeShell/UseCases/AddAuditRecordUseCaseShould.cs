using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell.Domain;
using Day21.FunctionalCore_ImperativeShell.UseCases;
using Day21.Tests.FunctionalCore_ImperativeShell.Common.Setup;
using Day21.Tests.FunctionalCore_ImperativeShell.Common.TestDoubles;
using Day21.Tests.FunctionalCore_ImperativeShell.Common.Verification;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell.UseCases;

public class AddAuditRecordUseCaseShould
{
    private const string DirectoryName = "audits";

    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private static readonly List<FileContent> NoFiles = [];
    private static readonly ImmutableList<string> NoContent = [];
    private static readonly AddNewVisitor Command = new("Alice", DateTime.Parse("2019-04-06T18:00:00"));

    private readonly AuditManager _auditManager = new(3);
    private readonly IFileRepository _persister = new InMemoryFileRepository();

    private readonly AddAuditRecordUseCase _useCase;

    public AddAuditRecordUseCaseShould() =>
        _useCase = new AddAuditRecordUseCase(DirectoryName, _auditManager, _persister);

    [Fact]
    public void Adds_new_visitor_to_a_new_file_because_no_file_today()
    {
        AlreadyContains(NoFiles);

        AddRecord();

        ShouldContains(FileContent("audit_1.txt", ContentFrom(NewContent)));
    }


    [Fact]
    public void Adds_new_visitor_to_an_existing_file()
    {
        AlreadyContains(
            FileContent(
                "audit_1.txt",
                ContentFrom("Peter;2019-04-06 16:30:00", "Jane;2019-04-06 16:40:00")));

        AddRecord();

        ShouldContains(
            FileContent(
                "audit_1.txt",
                ContentFrom("Peter;2019-04-06 16:30:00", "Jane;2019-04-06 16:40:00", NewContent)));
    }


    [Fact]
    public void Adds_new_visitor_to_a_new_file_when_end_of_last_file_is_reached()
    {
        AlreadyContains(
            Files(
                FileContent("audit_1.txt", NoContent),
                FileContent(
                    "audit_2.txt",
                    ContentFrom(
                        "Peter;2019-04-06 16:30:00",
                        "Jane;2019-04-06 16:40:00",
                        "Jack;2019-04-06 17:00:00"))));

        AddRecord();

        ShouldContains(FileContent("audit_3.txt", ContentFrom(NewContent)));
    }


    private void AddRecord() => _useCase.Handle(Command);

    private static List<FileContent> Files(params FileContent[] files) => [..files];

    private static FileContent FileContent(string fileName, ImmutableList<string> lines) =>
        new(fileName, lines);

    private static ImmutableList<string> ContentFrom(params string[] content) => [..content];

    private void ShouldContains(FileContent fileContent) =>
        _persister.ShouldContains(DirectoryName, fileContent);

    private void AlreadyContains(FileContent file) =>
        _persister.AlreadyContains(
            DirectoryName,
            file);

    private void AlreadyContains(List<FileContent> files) =>
        _persister.AlreadyContains(
            DirectoryName,
            files);
}