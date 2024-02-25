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
    IVerifiedPointsService verifiedPointsService)
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
                Latitude = request.NewVerifiedPoint.Latitude, Longitude = request.NewVerifiedPoint.Longitude
            },
            segments!);
        NotFoundException.ThrowIfNull(nearestSegment, RoadErrors.NoSuchRoadWithName(request.RoadName));

        await verifiedPointsService.CreateAndSaveGasStationAsync(request.NewVerifiedPoint.Name, nearestSegment,
            request.NewVerifiedPoint.Latitude, request.NewVerifiedPoint.Longitude, ct);
    }
}