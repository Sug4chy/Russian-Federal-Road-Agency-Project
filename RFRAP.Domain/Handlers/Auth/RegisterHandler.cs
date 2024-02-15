using FluentValidation;
using Microsoft.AspNetCore.Identity;
using RFRAP.Data.Entities;
using RFRAP.Domain.Exceptions;
using RFRAP.Domain.Requests.Auth;
using RFRAP.Domain.Responses.Auth;

namespace RFRAP.Domain.Handlers.Auth;

public class RegisterHandler(UserManager<User> manager)
{
    public async Task<RegisterResponse> HandleAsync(
        RegisterRequest request, 
        CancellationToken ct = default)
    {
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
        
        throw new BadRequestException(
            string.Join(", ", creationResult.Errors.Select(e => e.Description))
        );
    }
}