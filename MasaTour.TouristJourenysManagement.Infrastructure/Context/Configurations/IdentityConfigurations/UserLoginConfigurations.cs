﻿namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserLoginConfigurations : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(Tables.Identity.UserLogins);
    }
}
