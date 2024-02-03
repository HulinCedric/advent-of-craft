namespace Day01;

using Clock = Func<DateOnly>;

public record Food(
    DateOnly ExpirationDate,
    bool ApprovedForConsumption,
    Guid? InspectorId)
{
    public bool IsEdible(Clock now)
        => IsFresh(now) &&
           CanBeConsumed() &&
           HaveBeenInspected();

    private bool IsFresh(Clock now)
        => ExpirationDate > now();

    private bool CanBeConsumed()
        => ApprovedForConsumption;

    private bool HaveBeenInspected()
        => InspectorId != null;
}