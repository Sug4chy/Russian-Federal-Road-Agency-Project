using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public interface IUnverifiedPointsService
{
    UnverifiedPoint CreatePoint(double x, double y, Segment segment);
}