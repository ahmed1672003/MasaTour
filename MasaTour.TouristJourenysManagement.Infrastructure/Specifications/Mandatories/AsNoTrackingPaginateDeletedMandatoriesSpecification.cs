namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingPaginateDeletedMandatoriesSpecification : Specification<Mandatory>
{
    public AsNoTrackingPaginateDeletedMandatoriesSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<Mandatory, object>> orderBy = null)
        : base(m => (m.IsDeleted) &
        (
        m.NameAR.Contains(keyWords) ||
        m.NameEN.Contains(keyWords) ||
        m.NameDE.Contains(keyWords) ||
        m.DesceiptionAR.Contains(keyWords) ||
        m.DesceiptionEN.Contains(keyWords) ||
        m.DesceiptionDE.Contains(keyWords)))
    {
        StopTracking();
        IgnorQueryFilter();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
        // AddIncludes(m => m.TripMandatoryMapper);
    }
}
