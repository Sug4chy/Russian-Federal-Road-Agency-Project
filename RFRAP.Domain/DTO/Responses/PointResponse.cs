using RFRAP.Domain.Interfaces;

namespace RFRAP.Domain.DTO.Responses;

public record PointResponse : IResponse
{
    public MarkerPointDTO[] Point { get; init; }
}