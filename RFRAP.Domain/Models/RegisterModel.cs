﻿using RFRAP.Data.Entities;

namespace RFRAP.Domain.Models;

public record RegisterModel
{
    public required User User { get; init; }
    public required string Password { get; init; }
}