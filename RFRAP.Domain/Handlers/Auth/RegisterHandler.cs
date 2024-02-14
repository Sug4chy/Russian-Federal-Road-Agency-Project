using FluentValidation;
using Microsoft.AspNetCore.Identity;
using RFRAP.Data.Entities;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;

namespace RFRAP.Domain.Handlers.Auth;

public class RegisterHandler(
    IValidator<RegisterRequest> validator,
    UserManager<User> manager)
{
    public async Task<RegisterResponse> HandleAsync(
        RegisterRequest request, 
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var managedUser = await manager.FindByEmailAsync(request.Email);
        if (managedUser is not null)
            throw new BadRequestException("Bad credentials");

        var creationResult = await manager.CreateAsync(
            new User {UserName = request.Name, Email = request.Email, Name = request.Name},
            request.Password
        );

        if (creationResult.Succeeded)
        {
            return new RegisterResponse
            {
                Email = request.Email
            };
        }
        
        // result.Errors
        throw new BadRequestException("result.Errors string example");
    }
}