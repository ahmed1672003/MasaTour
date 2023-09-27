namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetDeletedCategoryByNameARSpecification : Specification<Category>
{
    public AsNoTrackingGetDeletedCategoryByNameARSpecification(string nameAR) : base(c => c.NameAR.Equals(nameAR) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
