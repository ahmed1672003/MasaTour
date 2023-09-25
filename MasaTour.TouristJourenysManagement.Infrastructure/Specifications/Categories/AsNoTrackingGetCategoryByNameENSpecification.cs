namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetCategoryByNameENSpecification : Specification<Category>
{
    public AsNoTrackingGetCategoryByNameENSpecification(string nameEN) : base(category => category.NameEN.Equals(nameEN))
    {
        StopTracking();
    }
}
