namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class ImageConfigurations : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable(Tables.Images);
    }
}
