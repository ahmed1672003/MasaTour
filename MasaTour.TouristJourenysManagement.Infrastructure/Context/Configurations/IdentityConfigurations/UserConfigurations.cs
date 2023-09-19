namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Tables.Identity.Users);
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Email).IsUnique(true);
        builder.HasIndex(t => t.UserName).IsUnique(true);
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
