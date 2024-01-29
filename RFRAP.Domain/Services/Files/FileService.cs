using Microsoft.Extensions.Options;
using RFRAP.Data.Context;
using RFRAP.Data.Entities;
using RFRAP.Domain.ConfigurationOptions.Files;
using RFRAP.Domain.DTOs;

namespace RFRAP.Domain.Services.Files;

public class FileService(
    IOptions<UploadFilesOptions> options,
    AppDbContext context) : IFileService
{
    private readonly UploadFilesOptions _uploadFilesOptions = options.Value;
    
    public async Task SaveAttachmentFileAsync(FileDto fileDto, UnverifiedPoint point, CancellationToken ct = default)
    {
        if (!Directory.Exists(_uploadFilesOptions.AbsolutePath))
        {
            Directory.CreateDirectory(_uploadFilesOptions.AbsolutePath);
        }

        string uniqueName = GetUniqueName(fileDto.FileName);
        await using var fs = new FileStream($"{_uploadFilesOptions.AbsolutePath}/{uniqueName}", 
            FileMode.Create);
        await fileDto.ReadStream.CopyToAsync(fs, ct);

        await context.Files.AddAsync(new AttachmentFile
        {
            ContentType = fileDto.ContentType,
            UniqueName = uniqueName,
            Point = point,
            PointId = point.Id
        }, ct);
        await context.SaveChangesAsync(ct);
    }

    private static string GetUniqueName(string originalName)
        => $"{Path.GetRandomFileName()}{Path.GetExtension(originalName)}";
}