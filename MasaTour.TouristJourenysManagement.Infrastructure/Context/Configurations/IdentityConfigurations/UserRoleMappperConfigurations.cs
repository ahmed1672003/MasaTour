namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class UserRoleMappperConfigurations : IEntityTypeConfiguration<UserRoleMapper>
{
    public void Configure(EntityTypeBuilder<UserRoleMapper> builder)
    {
        builder.ToTable(Tables.Identity.UserRolesMappers);
    }
}
