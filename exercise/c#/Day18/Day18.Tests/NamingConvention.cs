using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Day18.Tests;

public class NamingConvention
{
    private const string BadNamingUrl =
        "https://yoan-thirion.gitbook.io/knowledge-base/software-craftsmanship/the-programmers-brain#perspective-1-a-good-name-can-be-defined-syntactically";

    [Fact]
    public void Fields_Should_Not_Contain_Consecutive_Underscores()
        => FieldMembers().That()
            .HaveNameContaining("__")
            .Should()
            .NotExist()
            .Because($"__ ruins readability : {BadNamingUrl}")
            .Check();

    [Fact]
    public void Fields_Should_Not_Start_Or_End_With_Underscore()
        => FieldMembers().That()
            .HaveNameStartingWith("_").Or()
            .HaveNameEndingWith("_")
            .Should()
            .NotExist()
            .Because($"__ ruins readability : {BadNamingUrl}")
            .Check();
}