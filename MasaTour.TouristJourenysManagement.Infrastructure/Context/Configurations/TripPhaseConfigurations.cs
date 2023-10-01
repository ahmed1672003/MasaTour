namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TripPhaseConfigurations : IEntityTypeConfiguration<TripPhase>
{
    public void Configure(EntityTypeBuilder<TripPhase> builder)
    {
        builder.ToTable(Tables.TripPhases);
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
