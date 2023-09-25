namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsTrackingGetCategoryByIdSpecification : Specification<Category>
{
    public AsTrackingGetCategoryByIdSpecification(string id) : base(category => category.Id.Equals(id))
    {

    }
}
