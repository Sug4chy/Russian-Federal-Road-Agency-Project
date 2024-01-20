using FluentValidation;
using RFRAP.Data.UnitOfWork;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests;
using RFRAP.Domain.Services.GasStations;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers;

public class AddGasStationHandler(
    IValidator<AddGasStationRequest> validator,
    ISegmentService segmentService,
    IGasStationService gasStationService,
    IUnitOfWork unitOfWork)
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

        var gasStation = gasStationService.CreateGasStation(request.NewGasStation.Name, nearestSegment!,
            request.NewGasStation.X, request.NewGasStation.Y);
        
        await unitOfWork.GasStations.AddAsync(gasStation, ct);
        await unitOfWork.SaveChangesAsync(ct);
    }
}