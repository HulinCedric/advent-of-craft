using FluentAssertions;
using Xunit;

namespace Day21.Tests;

public class AuditManagerTests
{
    private const string DirectoryName = "audits";

    [Fact]
    public void A_New_File_Is_Created_When_The_Current_File_Overflows()
    {
        var fakeFileSystem = new FakeFileSystem();
        fakeFileSystem.AddFile(DirectoryName, "audit_1.txt", []);
        fakeFileSystem.AddFile(DirectoryName, "audit_2.txt",
        [
            "Peter;2019-04-06 16:30:00",
            "Jane;2019-04-06 16:40:00",
            "Jack;2019-04-06 17:00:00"
        ]);

        var sut = new AuditManager(3, DirectoryName, fakeFileSystem);

        sut.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        fakeFileSystem.ReadAllLines(Path.Combine(DirectoryName, "audit_3.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Alice;2019-04-06 18:00:00"
            ]);
    }

    [Fact]
    public void Append_To_Current_File_When_Current_File_Not_Full()
    {
        var fakeFileSystem = new FakeFileSystem();
        fakeFileSystem.AddFile(DirectoryName, "audit_1.txt",
        [
            "Peter;2019-04-06 16:30:00",
            "Jane;2019-04-06 16:40:00"
        ]);
        
        var sut = new AuditManager(3, DirectoryName, fakeFileSystem);

        sut.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        fakeFileSystem.ReadAllLines(Path.Combine(DirectoryName, "audit_1.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Peter;2019-04-06 16:30:00",
                "Jane;2019-04-06 16:40:00",
                "Alice;2019-04-06 18:00:00"
            ]);
    }

    [Fact]
    public void A_New_File_Is_Created_When_No_Files()
    {
        var fakeFileSystem = new FakeFileSystem();

        var sut = new AuditManager(3, DirectoryName, fakeFileSystem);

        sut.AddRecord("Alice", DateTime.Parse("2019-04-06T18:00:00"));

        fakeFileSystem.ReadAllLines(Path.Combine(DirectoryName, "audit_1.txt"))
            .Should()
            .BeEquivalentTo(
            [
                "Alice;2019-04-06 18:00:00"
            ]);
    }
}