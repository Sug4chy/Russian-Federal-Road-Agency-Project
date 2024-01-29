using RFRAP.Data.Entities;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Files;

public interface IFileService
{
    Task SaveAttachmentFileAsync(FileDto fileDto, UnverifiedPoint point, CancellationToken ct = default);
}