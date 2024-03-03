using Xunit;
using static Day18.Tests.ArchUnitExtensions;

namespace Day18.Tests;

public class LinguisticAntiPatterns
{
    [Fact]
    public void NoGetMethodShouldReturnVoid()
        => Methods()
            .HaveName("Get[A-Z].*", useRegularExpressions: true)
            .Should()
            .NotHaveReturnType(typeof(void))
            .Check();
}