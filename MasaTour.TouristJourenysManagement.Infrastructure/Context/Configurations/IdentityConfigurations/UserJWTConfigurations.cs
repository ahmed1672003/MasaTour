namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserJWTConfigurations : IEntityTypeConfiguration<UserJWT>
{
    public void Configure(EntityTypeBuilder<UserJWT> builder)
    {
        builder.ToTable(Tables.Identity.UserJWTs);
    }
}
