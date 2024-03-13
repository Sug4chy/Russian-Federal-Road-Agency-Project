using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Distance;

public interface IDistanceCalculator
{
    double GetDistanceFromUserToPointInKm(PointDto userCoordinates, PointDto pointCoordinates);
    double GetDistanceToSegment(PointDto point, Segment segment);
}