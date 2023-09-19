namespace ECommerce.Infrastructure.Context.Configurations.IdentityConfigurations;
public class UserJWTConfigurations : IEntityTypeConfiguration<UserJWT>
{
    public void Configure(EntityTypeBuilder<UserJWT> builder)
    {
        builder.ToTable(Tables.Identity.UserJWTs);
        builder.HasKey(t => new { t.Id, t.UserId });
        builder.Property(t => t.User).IsRequired(false);
        builder.Property(t => t.UserId).IsRequired(true);
        builder
            .HasOne(jwt => jwt.User)
            .WithMany(user => user.UserJWTs)
            .HasForeignKey(jwt => jwt.UserId);
    }
}
