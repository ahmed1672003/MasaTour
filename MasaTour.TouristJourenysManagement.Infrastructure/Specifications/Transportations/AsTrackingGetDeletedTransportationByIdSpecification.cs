namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsTrackingGetDeletedTransportationByIdSpecification : Specification<Transportation>
{
    public AsTrackingGetDeletedTransportationByIdSpecification(string id)
        : base(t => t.IsDeleted && t.Id.Equals(id))
    {
        IgnorQueryFilter();
    }
}
