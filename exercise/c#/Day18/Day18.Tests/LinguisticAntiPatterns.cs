using Xunit;
using static Day18.Tests.ArchUnitExtensions;

namespace Day18.Tests;

public class LinguisticAntiPatterns
{
    [Fact]
    public void No_Get_Method_Should_Return_Void()
        => Methods()
            .HaveName("Get[A-Z].*", useRegularExpressions: true).Should()
            .NotHaveReturnType(typeof(void))
            .Because("any method which gets something should actually return something")
            .Check();

    [Fact]
    public void Iser_And_Haser_Should_Return_Booleans()
        => Methods()
            .HaveName("Is[A-Z].*", useRegularExpressions: true).Or()
            .HaveName("Has[A-Z].*", useRegularExpressions: true).Should()
            .HaveReturnType(typeof(bool))
            .Because("any method which fetch a state should actually return something (a boolean)")
            .Check();
}