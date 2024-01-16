namespace RFRAP.Domain.DTO.Responses;

public record PointResponse
{
    public required MarkerPointDTO[] Points { get; init; }
}