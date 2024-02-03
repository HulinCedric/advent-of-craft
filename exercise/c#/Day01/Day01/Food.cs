namespace Day01
{
    public record Food(
        DateOnly ExpirationDate,
        bool ApprovedForConsumption,
        Guid? InspectorId)
    {
        public bool IsEdible(Func<DateOnly> now)
            => ExpirationDate.CompareTo(now()) > 0 &&
               ApprovedForConsumption &&
               InspectorId != null;
    }
}