namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingPaginateUnDeletedMandatoriesSpecification : Specification<Mandatory>
{
    public AsNoTrackingPaginateUnDeletedMandatoriesSpecification(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", Expression<Func<Mandatory, object>> orderBy = null)
        : base(m => m.NameAR.Contains(keyWords) || m.NameEN.Contains(keyWords) || m.NameDE.Contains(keyWords))
    {
        StopTracking();
        ApplyPaging((pageNumber.Value, pageSize.Value));
        AddOrderBy(orderBy);
    }
}
