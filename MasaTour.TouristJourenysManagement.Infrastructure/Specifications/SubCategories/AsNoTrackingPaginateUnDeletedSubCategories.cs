namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
public sealed class AsNoTrackingPaginateUnDeletedSubCategories : Specification<SubCategory>
{
    public AsNoTrackingPaginateUnDeletedSubCategories(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<SubCategory, object>> orderBy = null)
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
    }
}
