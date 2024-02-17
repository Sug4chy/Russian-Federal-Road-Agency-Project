using FluentValidation;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
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
        NotFoundException.ThrowIfNull(segments, RoadErrors.NoSuchRoadWithName(request.RoadName));

        var nearestSegment = segmentService.GetNearestSegmentByCoordinates(
            new PointDto
            {
                Latitude = request.NewGasStation.Latitude, Longitude = request.NewGasStation.Longitude
            },
            segments!);
        NotFoundException.ThrowIfNull(nearestSegment, RoadErrors.NoSuchRoadWithName(request.RoadName));

        await gasStationService.CreateAndSaveGasStationAsync(request.NewGasStation.Name, nearestSegment,
            request.NewGasStation.Latitude, request.NewGasStation.Longitude, ct);
    }
}