using Microsoft.Extensions.Time.Testing;

namespace Day04.Tests;

public static class FakeClockExtensions
{
    public static void AddDays(this FakeTimeProvider fakeTimeProvider, int days)
        => fakeTimeProvider.SetUtcNow(fakeTimeProvider.GetUtcNow().AddDays(days));
}