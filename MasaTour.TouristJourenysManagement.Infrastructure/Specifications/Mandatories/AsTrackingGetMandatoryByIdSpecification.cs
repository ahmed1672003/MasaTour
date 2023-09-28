namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsTrackingGetMandatoryByIdSpecification : Specification<Mandatory>
{
    public AsTrackingGetMandatoryByIdSpecification(string id) : base(m => m.Id.Equals(id))
    {

    }
}
