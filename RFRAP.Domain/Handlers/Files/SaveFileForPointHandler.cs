using FluentValidation;
using RFRAP.Domain.Exceptions;
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

        var point = await unverifiedPointsService.GetPointByIdAsync(request.UnverifiedPointId, ct);
        NotFoundException.ThrowIfNull(point, nameof(point));
        ConflictException.ThrowIfNotNull(point?.File, nameof(point), 
            nameof(point.File));

        await fileService.SaveAttachmentFileAsync(request.File, point!, ct);
    }
}