namespace Day04;

public static class ClockExtensions
{
    public static DateOnly Today(this TimeProvider clock)
        => DateOnly.FromDateTime(clock.GetUtcNow().DateTime);
}