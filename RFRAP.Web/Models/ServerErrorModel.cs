namespace RFRAP.Web.Models;

public record ServerErrorModel
{
    public required string ErrorCode { get; init; }
    public required string ErrorMessage { get; init; }
}