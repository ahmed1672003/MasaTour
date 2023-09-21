namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Roles;
public sealed class GetRolesByNameSpecification : Specification<Role>
{
    public GetRolesByNameSpecification(List<string> rolesNames) : base(role => rolesNames.Contains(role.Name))
    {

    }
}
