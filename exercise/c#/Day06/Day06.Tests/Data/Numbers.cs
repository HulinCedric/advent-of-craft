using Xunit;

namespace Day06.Tests.Data;

public class Numbers : TheoryData<int, string>
{
    public Numbers()
    {
        Add(1, "1");
        Add(67, "67");
        Add(82, "82");
    }
}