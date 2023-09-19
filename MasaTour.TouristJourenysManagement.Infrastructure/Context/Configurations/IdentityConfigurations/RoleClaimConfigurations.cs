namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(Tables.Identity.RoleClaims);
        builder.HasKey(t => t.Id);
    }
}
