namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class CategoriesTripsMapperConfigurations : IEntityTypeConfiguration<CategoriesTripsMapper>
{
    public void Configure(EntityTypeBuilder<CategoriesTripsMapper> builder)
    {
        builder.ToTable(Tables.CategoriesTripsMappers);
    }
}
