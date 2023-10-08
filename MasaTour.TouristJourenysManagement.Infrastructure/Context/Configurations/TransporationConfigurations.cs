namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class TransporationConfigurations : IEntityTypeConfiguration<Transporation>
{
    public void Configure(EntityTypeBuilder<Transporation> builder)
    {
        builder.ToTable(Tables.Transporations);
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
