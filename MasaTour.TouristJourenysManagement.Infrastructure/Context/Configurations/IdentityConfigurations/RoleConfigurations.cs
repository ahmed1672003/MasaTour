namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(Tables.Identity.Roles);
    }
}
