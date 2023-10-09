namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TransportationConfigurations : IEntityTypeConfiguration<Transportation>
{
    public void Configure(EntityTypeBuilder<Transportation> builder)
    {
        builder.ToTable(Tables.Transportations);
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
