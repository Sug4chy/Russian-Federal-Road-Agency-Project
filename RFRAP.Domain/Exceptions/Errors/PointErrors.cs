namespace RFRAP.Domain.Exceptions.Errors;

public static class PointErrors
{
    public static Error NoSuchPointWithId(Guid id)
        => new(nameof(NoSuchPointWithId), $"Point with id {id} doesn't exist");
}