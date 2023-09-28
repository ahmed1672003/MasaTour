namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingPaginateDeletedSubCategoriesSpecification : Specification<SubCategory>
{
    public AsNoTrackingPaginateDeletedSubCategoriesSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<SubCategory, object>> orderBy = null)
        : base(sc => (sc.IsDeleted) &&
        ((sc.NameAR.Contains(keyWords)) ||
        (sc.NameAR.Contains(keyWords)) ||
        (sc.NameDE.Contains(keyWords)) ||
        (sc.Id.Contains(keyWords)))
        )
    {
        StopTracking();
        IgnorQueryFilter();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
    }
}
