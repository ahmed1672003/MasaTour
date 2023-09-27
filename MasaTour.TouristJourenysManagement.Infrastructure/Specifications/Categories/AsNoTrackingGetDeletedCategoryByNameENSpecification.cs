namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetDeletedCategoryByNameENSpecification : Specification<Category>
{
    public AsNoTrackingGetDeletedCategoryByNameENSpecification(string nameEN) : base(c => c.NameEN.Equals(nameEN) && c.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}