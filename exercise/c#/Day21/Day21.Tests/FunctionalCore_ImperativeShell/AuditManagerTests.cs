using System.Collections.Immutable;
using Day21.FunctionalCore_ImperativeShell;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class AuditManagerTests
{
    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private const string VisitorName = "Alice";
    private static readonly List<FileContent> NoFiles = [];
    private static readonly ImmutableList<string> NoContent = [];
    private static readonly DateTime TimeOfVisit = DateTime.Parse("2019-04-06T18:00:00");
    private readonly AuditManager _audit = new(3);

    [Fact]
    public void Adds_new_visitor_to_a_new_file_because_no_file_today() =>
        AddRecord(NoFiles)
            .Should()
            .BeEquivalentTo(new FileUpdated("audit_1.txt", NewContent));

    [Fact]
    public void Adds_new_visitor_to_an_existing_file() =>
        AddRecord(Files(FileContent("audit_1.txt", ContentFrom("Peter;2019-04-06 16:30:00"))))
            .Should()
            .BeEquivalentTo(
                new FileUpdated(
                    "audit_1.txt",
                    $"Peter;2019-04-06 16:30:00{Environment.NewLine}{NewContent}"));


    [Fact]
    public void Adds_new_visitor_to_a_new_file_when_end_of_last_file_is_reached()
    {
        var files = Files(
            FileContent("audit_1.txt", NoContent),
            FileContent(
                "audit_2.txt",
                ContentFrom(
                    "Peter;2019-04-06 16:30:00",
                    "Jane;2019-04-06 16:40:00",
                    "Jack;2019-04-06 17:00:00")));

        AddRecord(files)
            .Should()
            .BeEquivalentTo(new FileUpdated("audit_3.txt", NewContent));
    }

    private FileUpdated AddRecord(List<FileContent> files) =>
        _audit.AddRecord(files, VisitorName, TimeOfVisit);

    private static List<FileContent> Files(params FileContent[] files) => [..files];

    private static FileContent FileContent(string fileName, ImmutableList<string> lines) =>
        new(fileName, lines);

    private static ImmutableList<string> ContentFrom(params string[] content) => [..content];
}