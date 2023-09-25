using MasaTour.TouristJourenysManagement.Domain.Entities;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations;
public sealed class CategoriesJourneysMapperConfigurations : IEntityTypeConfiguration<CategoriesJourneysMapper>
{
    public void Configure(EntityTypeBuilder<CategoriesJourneysMapper> builder)
    {
        builder.ToTable(Tables.CategoriesJourneysMappers);
    }
}
