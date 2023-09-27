namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetDeletedSubCategoryByIdSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetDeletedSubCategoryByIdSpecification(string id) : base(sc => sc.Id.Equals(id))
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
