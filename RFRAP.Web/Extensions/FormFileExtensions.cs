using RFRAP.Domain.DTOs;

namespace RFRAP.Web.Extensions;

public static class FormFileExtensions
{
    public static FileDto ToFileDto(this IFormFile file)
        => new()
        {
            ContentType = file.ContentType,
            FileName = file.FileName,
            ReadStream = file.OpenReadStream()
        };
}