namespace RFRAP.Domain.Responses;

public record AddUnverifiedPointResponse
{
    public required Guid AddedPointId { get; init; }
}