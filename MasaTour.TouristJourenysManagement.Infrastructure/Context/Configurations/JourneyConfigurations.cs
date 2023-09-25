using MasaTour.TouristJourenysManagement.Domain.Entities;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations;
public sealed class JourneyConfigurations : IEntityTypeConfiguration<Journey>
{
    public void Configure(EntityTypeBuilder<Journey> builder)
    {
        builder.ToTable(Tables.Journeys);
    }
}
