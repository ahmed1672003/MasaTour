namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetDeletedSubCategoryByNameARSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetDeletedSubCategoryByNameARSpecification(string nameAR)
        : base(sc => sc.NameAR.Equals(nameAR) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
