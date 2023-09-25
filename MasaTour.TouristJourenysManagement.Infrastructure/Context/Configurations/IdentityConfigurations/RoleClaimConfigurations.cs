namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(Tables.Identity.RoleClaims);
    }
}
