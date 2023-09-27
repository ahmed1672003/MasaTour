namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsTrackingGetDeletedSubCategoryByIdSpecification : Specification<SubCategory>
{
    public AsTrackingGetDeletedSubCategoryByIdSpecification(string id) : base(sc => sc.Id.Equals(id) && sc.IsDeleted)
    {
        IgnorQueryFilter();
    }
}
