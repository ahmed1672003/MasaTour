namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TripMandatoryMapperConfigurations : IEntityTypeConfiguration<TripMandatoryMapper>
{
    public void Configure(EntityTypeBuilder<TripMandatoryMapper> builder)
    {
        builder.ToTable(Tables.TripMandatoryMappers);
    }
}
