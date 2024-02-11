using Xunit;

namespace Day06.Tests.Data;

public class BuzzNumbers : TheoryData<int, string>
{
    public BuzzNumbers()
    {
        Add(5, "Buzz");
        Add(50, "Buzz");
        Add(85, "Buzz");
    }
}