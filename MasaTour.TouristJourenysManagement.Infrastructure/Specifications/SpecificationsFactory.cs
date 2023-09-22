using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications;

public sealed class SpecificationsFactory : ISpecificationsFactory
{
    public ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "EmailIsExistSpecification" => new EmailIsExistSpecification(parameters[0]),
            "UserNameIsExistSpecification" => new UserNameIsExistSpecification(parameters[0]),
            "GetUserByUserNameOrEmailIncludedJwtSpecification" => new GetUserByUserNameOrEmailIncludedJwtSpecification(parameters[0]),
            "PhoneNumberIsExistSpecification" => new PhoneNumberIsExistSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }

    public ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "GetRolesByNameSpecification" => new GetRolesByNameSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }

    public ISpecification<UserJWT> CreateUserJWTSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "JwtIsExistSpecification" => new JwtIsExistSpecification(parameters[0], parameters[1]),
            "GetUserJWTByJwtAndRefreshJwtIncludedSpecification" => new GetUserJWTByJwtAndRefreshJwtIncludedSpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException()
        };
    }
}

