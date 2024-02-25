using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Validators;

public static class ValidationDefaults
{
    public static bool BeLongitude(double x)
        => x is >= 0D and <= 180D;

    public static bool BeLatitude(double y)
        => y is >= -90D and <= 90D;

    public static bool BeValidPoint(PointDto point)
        => BeLongitude(point.Longitude) && BeLatitude(point.Latitude);

    public static bool BeUnverifiedPointType(string type)
        => Enum.TryParse<UnverifiedPointType>(type, out _);

    public static bool BeVerifiedPointType(string? type)
        => type is not null && Enum.TryParse<VerifiedPointType>(type, out _);
}