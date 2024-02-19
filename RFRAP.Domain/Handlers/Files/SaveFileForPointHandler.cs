using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Exceptions.Errors;
using RFRAP.Domain.Requests.Files;
using RFRAP.Domain.Services.Files;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers.Files;

public class SaveFileForPointHandler(
    IValidator<SaveFileForPointRequest> validator,
    IUnverifiedPointsService unverifiedPointsService,
    IFileService fileService)
{
    public async Task HandleAsync(SaveFileForPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var point = await unverifiedPointsService.GetPointByIdAsync(request.UnverifiedPointId!.Value, ct);
        NotFoundException.ThrowIfNull(point, PointErrors.NoSuchPointWithId(request.UnverifiedPointId.Value));
        ConflictException.ThrowIfNotNull(point!.File, 
            ConflictErrors.ParamIsNotNull(nameof(point), nameof(point.File)));

        await fileService.SaveAttachmentFileAsync(request.File, point, ct);
    }
}