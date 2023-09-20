namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Tables.Identity.Users);
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
