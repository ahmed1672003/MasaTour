﻿namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
public class RefreshTokenRequestDto
{
    public string? JWT { get; set; }
    public string? RefreshToken { get; set; }
}