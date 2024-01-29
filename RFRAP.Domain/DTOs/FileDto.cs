namespace RFRAP.Domain.DTOs;

public record FileDto
{
    public required Stream ReadStream { get; init; }
    public required string FileName { get; init; }
    public required string ContentType { get; init; }
}