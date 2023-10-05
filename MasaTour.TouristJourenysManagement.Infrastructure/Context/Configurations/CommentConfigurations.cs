namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable(Tables.Comments);
    }
}
