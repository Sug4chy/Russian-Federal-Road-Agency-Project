using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.DTO.Responses;

public record RoadResponse : IResponse
{
    public required RoadDTO[] Road { get; init; }
}