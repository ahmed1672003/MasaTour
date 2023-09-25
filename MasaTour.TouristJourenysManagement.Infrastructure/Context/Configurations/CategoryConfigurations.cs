namespace MasaTour.TouristJourenysManagement.Infrastructure.Context.Configurations;

public sealed class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(Tables.Catgeories);
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
