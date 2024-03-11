using FluentValidation;
using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Mappers;
using RFRAP.Domain.Requests.Mobile;
using RFRAP.Domain.Responses.Mobile;
using RFRAP.Domain.Services.VerifiedPoints;

namespace RFRAP.Domain.Handlers.Mobile;

public class GetVerifiedPointsInRadiusHandler(
    IValidator<GetVerifiedPointsInRadiusRequest> validator,
    IVerifiedPointsService verifiedPointsService,
    IMapper<VerifiedPoint, MobileVerifiedPointDto> mapper)
{
    public async Task<GetVerifiedPointsInRadiusResponse> HandleAsync(GetVerifiedPointsInRadiusRequest request,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var points = await verifiedPointsService
            .GetVerifiedPointsInRadiusAsync(request.Coordinates, 100, ct);

        return new GetVerifiedPointsInRadiusResponse
        {
            Points = points.Select(mapper.Map).ToArray()
        };
    }
}