namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(Tables.Identity.Roles);
    }
}
