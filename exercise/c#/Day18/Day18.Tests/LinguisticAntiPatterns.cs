using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Syntax.Elements.Members.MethodMembers;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Day18.Tests;

public class LinguisticAntiPatterns
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(ShittyClass).Assembly).Build();

    private static GivenMethodMembersThat Methods()
        => MethodMembers().That().AreNoConstructors().And();

    [Fact]
    public void NoGetMethodShouldReturnVoid()
        => Methods()
            .HaveName("Get[A-Z].*", useRegularExpressions: true)
            .Should()
            .NotHaveReturnType(typeof(void))
            .Check(Architecture);
}