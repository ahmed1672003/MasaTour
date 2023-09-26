namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TripConfigurations : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.ToTable(Tables.Trips);
        builder.HasQueryFilter(J => !J.IsDeleted);
        builder.Property(j => j.PriceEGP).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceUSD).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceGBP).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceEUR).HasColumnType("decimal(18, 5)");
    }
}
