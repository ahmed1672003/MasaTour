namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserClaimConfigurations : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(Tables.Identity.UserClaims);
        builder.HasKey(t => t.Id);
    }
}
