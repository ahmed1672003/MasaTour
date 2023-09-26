using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;

namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications;

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
            "AsNoTrackingGetDeletedUserByIdSpecification" => new AsNoTrackingGetDeletedUserByIdSpecification(parameters[0]),
            "AsTrackingGetUserByUserNameOrEmailSpecification" => new AsTrackingGetUserByUserNameOrEmailSpecification(parameters[0]),
            "AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification" => new AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification(parameters[0]),
            "AsTrackingGetUserByIdSpecification" => new AsTrackingGetUserByIdSpecification(parameters[0]),
            "AsTrackingGetDeletedUserByIdSpecification" => new AsTrackingGetDeletedUserByIdSpecification(parameters[0]),
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
    public ISpecification<Category> CreatCategorySpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDuplicatedCategoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedCategoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedCategoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedCategoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedCategoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedCategoryByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetCategoryByIdSpecification" => new AsNoTrackingGetCategoryByIdSpecification(parameters[0]),
            "AsNoTrackingGetCategoryByNameARSpecification" => new AsNoTrackingGetCategoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetCategoryByNameDESpecification" => new AsNoTrackingGetCategoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetCategoryByNameENSpecification" => new AsNoTrackingGetCategoryByNameENSpecification(parameters[0]),
            "AsNoTrackingGetDeletedCategoryByIdSpecification" => new AsNoTrackingGetDeletedCategoryByIdSpecification(parameters[0]),
            "AsNoTrackingPaginateCategoriesSpecification" => new AsNoTrackingPaginateCategoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingGetAllCategoriesSpecification" => new AsNoTrackingGetAllCategoriesSpecification(),
            "AsNoTrackingGetAllActiveCategoriesSpecification" => new AsNoTrackingGetAllActiveCategoriesSpecification(),
            "AsNoTrackingGetAllDeletedCategoriesSpecification" => new AsNoTrackingGetAllDeletedCategoriesSpecification(),
            "AsNoTrackingGetAllNotActiveCategoriesSpecification" => new AsNoTrackingGetAllNotActiveCategoriesSpecification(),
            "AsTrackingGetDeletedCategoryByIdSpecification" => new AsTrackingGetDeletedCategoryByIdSpecification(parameters[0]),
            "AsTrackingGetCategoryByIdSpecification" => new AsTrackingGetCategoryByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Trip> CreatTripSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDuplicatedTripByNameARSpecification" => new AsNoTrackingCheckDuplicatedTripByNameARSpecification(parameters[0], parameters[0]),
            "AsNoTrackingCheckDuplicatedTripByNameDESpecification" => new AsNoTrackingCheckDuplicatedTripByNameDESpecification(parameters[0], parameters[0]),
            "AsNoTrackingCheckDuplicatedTripByNameENSpecification" => new AsNoTrackingCheckDuplicatedTripByNameENSpecification(parameters[0], parameters[0]),
            "AsNoTrackingCheckDuplicatedTripByCodeSpecification" => new AsNoTrackingCheckDuplicatedTripByCodeSpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetAllActiveTripsSpecification" => new AsNoTrackingGetAllActiveTripsSpecification(),
            "AsNoTrackingGetAllDeletedTripsSpecification" => new AsNoTrackingGetAllDeletedTripsSpecification(),
            "AsNoTrackingGetAllTripsSpecification" => new AsNoTrackingGetAllTripsSpecification(),
            "AsNoTrackingGetAllNotActiveTripsSpecification" => new AsNoTrackingGetAllNotActiveTripsSpecification(),
            "AsNoTrackingGetAllFamousTripsSpecification" => new AsNoTrackingGetAllFamousTripsSpecification(),
            "AsNoTrackingGetAllUnFamousTripsSpecification" => new AsNoTrackingGetAllUnFamousTripsSpecification(),
            "AsNoTrackingGetDeletedTripByIdSpecification" => new AsNoTrackingGetDeletedTripByIdSpecification(parameters[0]),
            "AsNoTrackingGetTripByIdSpecification" => new AsNoTrackingGetTripByIdSpecification(parameters[0]),
            "AsNoTrackingGetTripByNameARSpecification" => new AsNoTrackingGetTripByNameARSpecification(parameters[0]),
            "AsNoTrackingGetTripByNameDESpecification" => new AsNoTrackingGetTripByNameDESpecification(parameters[0]),
            "AsNoTrackingGetTripByNameENSpecification" => new AsNoTrackingGetTripByNameENSpecification(parameters[0]),
            "AsNoTrackingGetTripByCodeSpecification" => new AsNoTrackingGetTripByCodeSpecification(parameters[0]),
            "AsNoTrackingPaginateTripsSpecification" => new AsNoTrackingPaginateTripsSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedTripByIdSpecification" => new AsTrackingGetDeletedTripByIdSpecification(parameters[0]),
            "AsTrackingGetTripByIdSpecification" => new AsTrackingGetTripByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
}

