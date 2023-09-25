namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class UserTokenConfigurations : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(Tables.Identity.UserTokens);
    }
}
