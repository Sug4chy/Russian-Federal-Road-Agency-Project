namespace RFRAP.Domain.DTO.Responses;

public record RoadResponse
{
    public required RoadDTO[] Roads { get; init; }
}