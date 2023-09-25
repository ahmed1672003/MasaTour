namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingGetCategoryByNameDESpecification : Specification<Category>
{
    public AsNoTrackingGetCategoryByNameDESpecification(string nameDE) : base(category => category.NameDE.Equals(nameDE))
    {
        StopTracking();
    }
}
