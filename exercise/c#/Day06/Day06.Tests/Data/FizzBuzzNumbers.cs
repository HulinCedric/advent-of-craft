using Xunit;

namespace Day06.Tests.Data;

public class FizzBuzzNumbers: TheoryData<int, string>
{
    public FizzBuzzNumbers()
    {
        Add(15, "FizzBuzz");
        Add(30, "FizzBuzz");
        Add(45, "FizzBuzz");
    }
}