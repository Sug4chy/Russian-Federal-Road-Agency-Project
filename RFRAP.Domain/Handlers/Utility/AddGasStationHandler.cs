using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests.Utility;
using RFRAP.Domain.Services.GasStations;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers.Utility;

public class AddGasStationHandler(
    IValidator<AddGasStationRequest> validator,
    ISegmentService segmentService,
    IGasStationService gasStationService)
{
    public async Task HandleAsync(AddGasStationRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var segments = await segmentService.GetSegmentsByRoadNameAsync(request.RoadName, ct);
        NotFoundException.ThrowIfNull(segments, nameof(segments));

        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(
            request.NewGasStation.X, request.NewGasStation.Y, segments!);
        NotFoundException.ThrowIfNull(nearestSegment, nameof(nearestSegment));
        
        await gasStationService.CreateAndSaveGasStationAsync(request.NewGasStation.Name, nearestSegment,
            request.NewGasStation.X, request.NewGasStation.Y, ct);
    }
}