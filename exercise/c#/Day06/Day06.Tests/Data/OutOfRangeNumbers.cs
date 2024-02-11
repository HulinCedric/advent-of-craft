using Xunit;

namespace Day06.Tests.Data;

public class OutOfRangeNumbers : TheoryData<int>
{
    public OutOfRangeNumbers()
    {
        Add(0);
        Add(101);
        Add(-1);
    }
}