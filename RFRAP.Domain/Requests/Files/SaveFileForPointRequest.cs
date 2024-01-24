using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Requests.Files;

public record SaveFileForPointRequest
{
    public required FileDto File { get; init; }
    public required Guid UnverifiedPointId { get; init; }
}