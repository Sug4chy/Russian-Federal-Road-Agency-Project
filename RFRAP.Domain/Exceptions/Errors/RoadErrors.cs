namespace RFRAP.Domain.Exceptions.Errors;

public static class RoadErrors
{
    public static Error NoSuchRoadWithName(string roadName)
        => new(nameof(NoSuchRoadWithName),
            $"Road with name {roadName} doesn't exist");
}