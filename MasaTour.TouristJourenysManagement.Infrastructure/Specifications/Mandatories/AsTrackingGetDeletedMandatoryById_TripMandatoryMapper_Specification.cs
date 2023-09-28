namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Mandatories;
public sealed class AsTrackingGetDeletedMandatoryById_TripMandatoryMapper_Specification : Specification<Mandatory>
{
    public AsTrackingGetDeletedMandatoryById_TripMandatoryMapper_Specification(string id) : base(m => m.Id.Equals(id) && m.IsDeleted)
    {
        IgnorQueryFilter();
        AddIncludes(m => m.TripMandatoryMapper);
    }
}
