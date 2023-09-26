namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TripConfigurations : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable(Tables.Trips);
        builder.HasQueryFilter(t => !t.IsDeleted);
        builder.Property(t => t.PriceEGP).HasColumnType("decimal(18, 5)");
        builder.Property(t => t.PriceUSD).HasColumnType("decimal(18, 5)");
        builder.Property(t => t.PriceGBP).HasColumnType("decimal(18, 5)");
        builder.Property(t => t.PriceEUR).HasColumnType("decimal(18, 5)");
    }
}
