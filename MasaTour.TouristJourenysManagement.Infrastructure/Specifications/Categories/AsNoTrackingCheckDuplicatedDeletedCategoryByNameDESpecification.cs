namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedDeletedCategoryByNameDESpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedDeletedCategoryByNameDESpecification(string categoryId, string nameDE)
        : base(c => c.NameDE.Equals(nameDE) && !c.Id.Equals(categoryId) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
