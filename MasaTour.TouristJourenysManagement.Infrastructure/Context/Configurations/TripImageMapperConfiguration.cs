namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TripImageMapperConfiguration : IEntityTypeConfiguration<TripImageMapper>
{
    public void Configure(EntityTypeBuilder<TripImageMapper> builder)
    {
        builder.ToTable(Tables.TripImageMapper);
    }
}
