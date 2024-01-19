namespace RFRAP.Web.Models;

public record ServerErrorModel
{
    public required int ErrorCode { get; init; }
    public required string ErrorMessage { get; init; }
}