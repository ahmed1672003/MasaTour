namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsTrackingGetDeletedMandatoryByIdSpecification : Specification<Mandatory>
{
    public AsTrackingGetDeletedMandatoryByIdSpecification(string id) : base(m => m.Id.Equals(id) && m.IsDeleted)
    {
        IgnorQueryFilter();
    }
}
