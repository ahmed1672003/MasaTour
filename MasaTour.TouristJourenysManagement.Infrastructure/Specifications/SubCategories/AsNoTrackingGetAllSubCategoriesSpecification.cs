namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingGetAllSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingGetAllSubCategoriesSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
