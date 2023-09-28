namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsNoTrackingetGetMandatoryByIdSpecification : Specification<Mandatory>
{
    public AsNoTrackingetGetMandatoryByIdSpecification(string id) : base(m => m.Id.Equals(id))
    {
        StopTracking();
    }
}
