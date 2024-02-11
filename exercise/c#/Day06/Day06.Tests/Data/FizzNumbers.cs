using Xunit;

namespace Day06.Tests.Data;

public class FizzNumbers: TheoryData<int, string>
{
    public FizzNumbers()
    {
        Add(3, "Fizz");
        Add(66, "Fizz");
        Add(99, "Fizz");
    }
}