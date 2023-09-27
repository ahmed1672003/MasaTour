namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetDeletedSubCategoryByNameDESpecification : Specification<SubCategory>
{
    public AsNoTrackingGetDeletedSubCategoryByNameDESpecification(string nameDE)
        : base(sc => sc.NameDE.Equals(nameDE) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
