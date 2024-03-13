namespace RFRAP.Domain.DTOs;

public record AdvertisementDto
{
    public required string Title { get; init; }
    public required string Message { get; init; }
}