using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Utility;
using RFRAP.Domain.Services.Roads;
using RFRAP.Domain.Services.Segments;

namespace RFRAP.Domain.Handlers.Utility;

public class AddSegmentHandler(
    IValidator<AddSegmentRequest> validator,
    IRoadService roadService,
    ISegmentService segmentService)
{
    public async Task HandleAsync(AddSegmentRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var road = await roadService.GetRoadByNameAsync(request.RoadName!, ct);
        NotFoundException.ThrowIfNull(road, RoadErrors.NoSuchRoadWithName(request.RoadName!));

        await segmentService.CreateAndSaveSegmentAsync(request.Segment, road!, ct);
    }
}