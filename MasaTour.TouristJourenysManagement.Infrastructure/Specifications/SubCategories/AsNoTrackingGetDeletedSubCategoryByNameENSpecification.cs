namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetDeletedSubCategoryByNameENSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetDeletedSubCategoryByNameENSpecification(string nameEN)
        : base(sc => sc.NameEN.Equals(nameEN) && sc.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
