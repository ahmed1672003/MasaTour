namespace MasaTour.TouristTripsManagement.Infrastructure.Context.Configurations;
public sealed class SubCategoryConfigurations : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.ToTable(Tables.SubCategories);
        builder.HasQueryFilter(sc => !sc.IsDeleted);
    }
}
