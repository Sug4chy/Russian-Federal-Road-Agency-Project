﻿using RFRAP.Data.Entities;
using RFRAP.Domain.Models;
using RFRAP.Domain.Results;

namespace RFRAP.Domain.Services.Auth;

public interface IAuthService
{
    Task<Result> RegisterUserAsync(RegisterModel registerModel, CancellationToken ct = default);
    Task<AuthTokensModel> GenerateAndSetTokensAsync(User user, CancellationToken ct = default);
}