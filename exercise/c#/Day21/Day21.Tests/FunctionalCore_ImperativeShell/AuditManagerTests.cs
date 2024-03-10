using Day21.FunctionalCore_ImperativeShell;
using FluentAssertions;
using Xunit;

namespace Day21.Tests.FunctionalCore_ImperativeShell;

public class AuditManagerTests
{
    private const string NewContent = "Alice;2019-04-06 18:00:00";
    private static readonly List<FileContent> NoFiles = [];
    private readonly AuditManager _audit = new(3);

    [Fact]
    public void Add_new_visitor_to_a_new_file_when_no_file_today() =>
        AddRecord(NoFiles)
            .Should()
            .BeEquivalentTo(new FileUpdated("audit_1.txt", NewContent));


    [Fact]
    public void Add_new_visitor_to_a_new_file_When_end_of_last_file_is_reached()
    {
        List<FileContent> files =
        [
            new FileContent("audit_1.txt", []),
            new FileContent(
                "audit_2.txt",
                [
                    "Peter;2019-04-06 16:30:00",
                    "Jane;2019-04-06 16:40:00",
                    "Jack;2019-04-06 17:00:00"
                ])
        ];

        AddRecord(files)
            .Should()
            .BeEquivalentTo(new FileUpdated("audit_3.txt", NewContent));
    }

    private FileUpdated AddRecord(List<FileContent> files) =>
        _audit.AddRecord(files, "Alice", DateTime.Parse("2019-04-06T18:00:00"));
}