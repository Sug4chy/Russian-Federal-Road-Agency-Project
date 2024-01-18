using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public interface IUnverifiedService
{
    UnverifiedPoint CreatePoint(double x, double y, Segment segment);
}