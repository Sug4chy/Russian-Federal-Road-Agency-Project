using FluentValidation;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests.Files;
using RFRAP.Domain.Services.UnverifiedPoints;

namespace RFRAP.Domain.Handlers.Files;

public class SaveFileForPointHandler(
    IValidator<SaveFileForPointRequest> validator,
    IUnverifiedPointsService unverifiedPointsService)
{
    public async Task HandleAsync(SaveFileForPointRequest request, CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var point = await unverifiedPointsService.GetPointByIdAsync(request.UnverifiedPointId, ct);
        NotFoundException.ThrowIfNull(point, nameof(point));
        
        string uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
        Directory.CreateDirectory(uploadPath);
        await using var fs = new FileStream($"{Directory.GetCurrentDirectory()}/uploads/{request.File.FileName}", FileMode.Create);
        await request.File.ReadStream.CopyToAsync(fs, ct);
    }
}