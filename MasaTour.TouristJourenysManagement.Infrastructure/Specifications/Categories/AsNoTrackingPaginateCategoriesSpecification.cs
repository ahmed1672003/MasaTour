namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
public sealed class AsNoTrackingPaginateCategoriesSpecification : Specification<Category>
{
    public AsNoTrackingPaginateCategoriesSpecification(int pageNumber = 1, int pageSize = 10, Expression<Func<Category, object>> orderBy = null)
    {
        ApplyPaging((pageNumber, pageSize));
        AddOrderBy(orderBy = category => category.CreatedAt);
    }
}
