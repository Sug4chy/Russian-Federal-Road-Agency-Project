using RFRAP.Data.Entities;

namespace RFRAP.Domain.Services.UnverifiedPoints;

public interface IUnverifiedPointsService
{
    Task CreateAndSavePointAsync(double x, double y, Segment segment, CancellationToken ct = default);
}