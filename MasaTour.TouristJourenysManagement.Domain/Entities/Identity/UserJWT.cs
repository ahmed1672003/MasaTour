﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class UserJWT
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string JWT { get; set; }
    public string RefreshJWT { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime JWTExpirationDate { get; set; }
    public DateTime RefreshJWTExpirtionDate { get; set; }
    public DateTime? RefreshJWTRevokedDate { get; set; }
    public bool IsRefreshJWTUsed { get; set; }
    public bool IsRefreshJWTActive => RefreshJWTRevokedDate is null && !IsRefreshJWTExpired;
    public bool IsRefreshJWTExpired => DateTime.UtcNow >= RefreshJWTExpirtionDate;

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public UserJWT() => Id = Guid.NewGuid().ToString();
}
