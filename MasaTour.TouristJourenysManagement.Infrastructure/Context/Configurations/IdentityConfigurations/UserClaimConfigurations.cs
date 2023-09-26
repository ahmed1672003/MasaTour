namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class UserClaimConfigurations : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(Tables.Identity.UserClaims);
    }
}
