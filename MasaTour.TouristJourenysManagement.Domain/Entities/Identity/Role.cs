﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public class Role : IdentityRole<string>
{
    [MaxLength(36)]
    public override string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; }

    [AllowNull]
    public IEnumerable<RoleClaim> RoleClaims { get; set; }

    [AllowNull]
    public IEnumerable<UserRoleMapper> UserRoleMappers { get; set; }
    public Role()
    {
        Id = Guid.NewGuid().ToString();
        RoleClaims = new HashSet<RoleClaim>();
        UserRoleMappers = new HashSet<UserRoleMapper>();
    }
}
