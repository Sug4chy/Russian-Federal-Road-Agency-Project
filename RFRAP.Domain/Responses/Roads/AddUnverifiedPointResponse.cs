namespace RFRAP.Domain.Responses.Roads;

public record AddUnverifiedPointResponse
{
    public required Guid AddedPointId { get; init; }
}