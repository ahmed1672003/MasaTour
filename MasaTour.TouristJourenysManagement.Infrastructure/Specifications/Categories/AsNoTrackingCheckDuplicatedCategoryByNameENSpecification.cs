namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingCheckDuplicatedCategoryByNameENSpecification : Specification<Category>
{
    public AsNoTrackingCheckDuplicatedCategoryByNameENSpecification(string categoryId, string nameEN)
        : base(category => category.NameEN.Equals(nameEN) && !category.Id.Equals(categoryId))
    {
        StopTracking();
    }
}
