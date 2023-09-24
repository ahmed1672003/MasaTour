namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Roles;
public sealed class AsNoTrackingGetRolesByNameSpecification : Specification<Role>
{
    public AsNoTrackingGetRolesByNameSpecification(IList<string> rolesNames) : base(role => rolesNames.Contains(role.Name))
    {
        StopTracking();
    }
}
