using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using static System.Math;

namespace RFRAP.Domain.Services.Distance;

public class DistanceCalculator : IDistanceCalculator
{
    public double GetDistanceFromUserToPointInKm(PointDto userCoordinates, PointDto pointCoordinates)
        => 111.2 * Acos(Sin(userCoordinates.Latitude) * Sin(pointCoordinates.Latitude) +
                        Cos(userCoordinates.Latitude) * Cos(pointCoordinates.Latitude) *
                        Cos(userCoordinates.Longitude - pointCoordinates.Longitude));

    public double GetDistanceToSegment(PointDto point, Segment segment)
    {
        var pointAb = new PointDto
        {
            Latitude = segment.Latitude2 - segment.Latitude1,
            Longitude = segment.Longitude1 - segment.Longitude2
        };
        var pointBe = new PointDto
        {
            Latitude = point.Latitude - segment.Latitude2,
            Longitude = point.Longitude - segment.Longitude2
        };
        var pointAe = new PointDto
        {
            Latitude = point.Latitude - segment.Latitude1,
            Longitude = point.Longitude - segment.Longitude1
        };

        double abBe = pointAb.Latitude * pointBe.Latitude + pointAb.Longitude * pointBe.Longitude;
        double abAe = pointAb.Latitude * pointAe.Latitude + pointAb.Longitude * pointAe.Longitude;
        double result;
        
        if (abBe > 0) 
        {
            double y = point.Longitude - segment.Longitude2;
            double x = point.Latitude - segment.Latitude2;
            result = Sqrt(x * x + y * y);
        }
        else if (abAe < 0)
        {
            double y = point.Longitude - segment.Longitude1;
            double x = point.Latitude - segment.Latitude1;
            result = Sqrt(x * x + y * y);
        }
        else
        {
            double x1 = pointAb.Latitude;
            double y1 = pointAb.Longitude;
            double x2 = pointAe.Latitude;
            double y2 = pointAe.Longitude;
            double mod = Sqrt(x1 * x1 + y1 * y1);
            result = Abs(x1 * y2 - y1 * x2) / mod;
        }

        return result;
    }
}