using FluentValidation;
using RFRAP.Domain.Requests.Auth;

namespace RFRAP.Domain.Validators.Auth;

public class RefreshRequestValidator : AbstractValidator<RefreshRequest>
{
    public RefreshRequestValidator()
    {
        RuleFor(request => request.RefreshToken).NotEmpty();
        RuleFor(request => request.ExpiredAccessToken).NotEmpty();
    }
}