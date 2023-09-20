﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public class RoleClaim : IdentityRoleClaim<string>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [Required]
    [MaxLength(36)]
    public override string RoleId { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimType { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimValue { get; set; }

    [AllowNull]
    [ForeignKey(nameof(RoleId))]
    public Role Role { get; set; }
    public RoleClaim()
    {
        Role = new();
    }
}