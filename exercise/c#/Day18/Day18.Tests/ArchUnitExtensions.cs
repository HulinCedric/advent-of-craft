using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Syntax.Elements.Members.MethodMembers;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;

namespace Day18.Tests;

public static class ArchUnitExtensions
{
    private static readonly Architecture Architecture =
        new ArchLoader()
            .LoadAssemblies(typeof(ShittyClass).Assembly)
            .Build();

    public static GivenMethodMembersThat Methods()
        => ArchRuleDefinition.MethodMembers().That().AreNoConstructors().And();

    public static void Check(this IArchRule archRule)
        => archRule.Check(Architecture);
}