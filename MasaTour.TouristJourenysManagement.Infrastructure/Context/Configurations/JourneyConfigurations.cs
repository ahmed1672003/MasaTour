namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations;
public sealed class JourneyConfigurations : IEntityTypeConfiguration<Journey>
{
    public void Configure(EntityTypeBuilder<Journey> builder)
    {
        builder.ToTable(Tables.Journeys);
        builder.Property(j => j.PriceLE).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceUSD).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceGBP).HasColumnType("decimal(18, 5)");
        builder.Property(j => j.PriceEUR).HasColumnType("decimal(18, 5)");
    }
}
