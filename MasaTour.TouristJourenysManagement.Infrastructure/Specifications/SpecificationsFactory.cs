using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications;

public sealed class SpecificationsFactory : ISpecificationsFactory
{
    public ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingEmailIsExistSpecification" => new AsNoTrackingEmailIsExistSpecification(parameters[0]),
            "AsNoTrackingUserNameIsExistSpecification" => new AsNoTrackingUserNameIsExistSpecification(parameters[0]),
            "AsNoTrackingPhoneNumberIsExistSpecification" => new AsNoTrackingPhoneNumberIsExistSpecification(parameters[0]),
            "AsNoTrackingUserIdIsExistSpecification" => new AsNoTrackingUserIdIsExistSpecification(parameters[0]),
            "AsNoTrackingCheckIfUserNameDuplicatedSpecification" => new AsNoTrackingCheckIfUserNameDuplicatedSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckIfPhoneNumberDuplicatedSpecification" => new AsNoTrackingCheckIfPhoneNumberDuplicatedSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckIfEmailDuplicatedSpecification" => new AsNoTrackingCheckIfEmailDuplicatedSpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetUserByIdSpecification" => new AsNoTrackingGetUserByIdSpecification(parameters[0]),
            "AsNoTrackingChangeVisibilitySpecification" => new AsNoTrackingChangeVisibilitySpecification(parameters[0], parameters[1]),
            "AsTrackingGetUserByUserNameOrEmailSpecification" => new AsTrackingGetUserByUserNameOrEmailSpecification(parameters[0]),
            "AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification" => new AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification(parameters[0]),
            "AsTrackingGetUserByIdSpecification" => new AsTrackingGetUserByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }

    public ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetRolesByNameSpecification" => new AsNoTrackingGetRolesByNameSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }

    public ISpecification<UserJWT> CreateUserJWTSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingJwtIsExistSpecification" => new AsNoTrackingJwtIsExistSpecification(parameters[0], parameters[1]),
            "AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification" => new AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException()
        };
    }
}

