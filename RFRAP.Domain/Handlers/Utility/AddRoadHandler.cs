using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Utility;
using RFRAP.Domain.Services.Roads;

namespace RFRAP.Domain.Handlers.Utility;

public class AddRoadHandler(
    IValidator<AddRoadRequest> validator, 
    IRoadService roadService)
{
    public async Task HandleAsync(AddRoadRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var road = await roadService.GetRoadByNameAsync(request.RoadDto.Name, ct);
        ConflictException.ThrowIfNotNull(road, 
            ConflictErrors.AlreadyExistsWithUniqueValue(nameof(road),
                nameof(road.Name), road?.Name!));
        
        await roadService.CreateAndSaveAsync(request.RoadDto, ct);
    }
}