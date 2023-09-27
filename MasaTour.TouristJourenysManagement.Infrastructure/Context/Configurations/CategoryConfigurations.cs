namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;

public sealed class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Tables.Categories);
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
