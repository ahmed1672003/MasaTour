namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetDeletedCategoryByNameDESpecification : Specification<Category>
{
    public AsNoTrackingGetDeletedCategoryByNameDESpecification(string nameDE) : base(c => c.NameDE.Equals(nameDE) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
