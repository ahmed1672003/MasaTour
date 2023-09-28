namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class MandatoryConfigurations : IEntityTypeConfiguration<Mandatory>
{
    public void Configure(EntityTypeBuilder<Mandatory> builder)
    {
        builder.ToTable(Tables.Mandatories);
        builder.HasQueryFilter(m => !m.IsDeleted);
    }
}
