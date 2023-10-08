namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;

public sealed class TransporationClassConfigurations : IEntityTypeConfiguration<TransporationClass>
{
    public void Configure(EntityTypeBuilder<TransporationClass> builder)
    {
        builder.ToTable(Tables.TransporationClasses);
        builder.Property(t => t.PriceGbpPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceEURPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceUSDPerKilometer).HasColumnType("decimal(18,5)");
        builder.Property(t => t.PriceEGPPerKilometer).HasColumnType("decimal(18,5)");
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
