using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Validators;

public static class ValidationDefaults
{
    private static bool BeLongitude(double x)
        => x is >= 0D and <= 180D;

    private static bool BeLatitude(double y)
        => y is >= -90D and <= 90D;

    public static bool BeValidPoint(PointDto point)
        => BeLongitude(point.Longitude) && BeLatitude(point.Latitude);

    private static bool BeUnverifiedPointType(string type)
        => Enum.TryParse<UnverifiedPointType>(type, out _);

    public static bool BeVerifiedPointType(string? type)
        => type is not null && Enum.TryParse<VerifiedPointType>(type, out _);

    public static bool BeValidFileDto(FileDto dto)
        => dto.FileName != "" && dto.ContentType != "";

    public static bool BeValidUnverifiedPointDto(UnverifiedPointDto dto)
        => (dto.Description is null || dto.Description.Length != 0)
           && BeUnverifiedPointType(dto.Type) 
           && BeValidPoint(dto.Coordinates);

    public static bool BeValidVerifiedPointDto(VerifiedPointDto dto)
        => dto.Name.Length != 0 && BeValidPoint(dto.Coordinates);
}