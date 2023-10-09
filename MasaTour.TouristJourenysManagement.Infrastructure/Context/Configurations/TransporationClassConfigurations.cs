namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;

public sealed class TransporationClassConfigurations : IEntityTypeConfiguration<TransportationClass>
{
    public void Configure(EntityTypeBuilder<TransportationClass> builder)
    {
        builder.ToTable(Tables.TransportationClasses);
        builder.Property(t => t.PriceGbpPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceEURPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceUSDPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceEGPPerKilometer).HasColumnType("decimal(18,5)");
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
