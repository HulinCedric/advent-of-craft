namespace Day13.Tests;

internal class Clock : IClock
{
    private DateOnly _today;

    public Clock(DateOnly today)
        => _today = today;

    public DateOnly Today()
        => _today;

    public void AddDays(int daysToAdd)
        => _today = _today.AddDays(daysToAdd);
}