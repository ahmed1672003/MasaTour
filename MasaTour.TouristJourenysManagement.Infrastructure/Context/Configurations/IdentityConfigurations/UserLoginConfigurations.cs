namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations.IdentityConfigurations;
public sealed class UserLoginConfigurations : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(Tables.Identity.UserLogins);
    }
}
