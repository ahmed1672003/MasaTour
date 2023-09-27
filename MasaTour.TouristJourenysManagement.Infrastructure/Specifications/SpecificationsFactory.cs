using MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
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
    public ISpecification<Category> CreateCategorySpecifications(Type type, params dynamic[] parameters)
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
            "AsNoTrackingPaginateUnDeletedCategoriesSpecification" => new AsNoTrackingPaginateUnDeletedCategoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingGetAllCategoriesSpecification" => new AsNoTrackingGetAllCategoriesSpecification(),
            "AsNoTrackingGetAllDeletedCategoriesSpecification" => new AsNoTrackingGetAllDeletedCategoriesSpecification(),
            "AsNoTrackingGetDeletedCategoryByNameARSpecification" => new AsNoTrackingGetDeletedCategoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetDeletedCategoryByNameDESpecification" => new AsNoTrackingGetDeletedCategoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetDeletedCategoryByNameENSpecification" => new AsNoTrackingGetDeletedCategoryByNameENSpecification(parameters[0]),
            "AsNoTrackingCheckDuplicatedDeletedCategoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedDeletedCategoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedCategoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedDeletedCategoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedCategoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedDeletedCategoryByNameENSpecification(parameters[0], parameters[1]),
            "AsTrackingGetDeletedCategoryByIdSpecification" => new AsTrackingGetDeletedCategoryByIdSpecification(parameters[0]),
            "AsTrackingGetCategoryByIdSpecification" => new AsTrackingGetCategoryByIdSpecification(parameters[0]),
            "AsTrackingGetDeletedCategoryById_SubCategories_Trips_Specification" => new AsTrackingGetDeletedCategoryById_SubCategories_Trips_Specification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<SubCategory> CreateSubCategorySpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDuplicatedSubCategoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedSubCategoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedSubCategoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedSubCategoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedSubCategoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedSubCategoryByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedDeletedSubCategoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetDeletedSubCategoryByNameARSpecification" => new AsNoTrackingGetDeletedSubCategoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetDeletedSubCategoryByNameDESpecification" => new AsNoTrackingGetDeletedSubCategoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetDeletedSubCategoryByNameENSpecification" => new AsNoTrackingGetDeletedSubCategoryByNameENSpecification(parameters[0]),
            "AsNoTrackingGetAllDeletedSubCategoriesSpecification" => new AsNoTrackingGetAllDeletedSubCategoriesSpecification(),
            "AsNoTrackingGetAllSubCategoriesSpecification" => new AsNoTrackingGetAllSubCategoriesSpecification(),
            "AsNoTrackingGetSubCategoryByIdSpecification" => new AsNoTrackingGetSubCategoryByIdSpecification(parameters[0]),
            "AsNoTrackingGetDeletedSubCategoryByIdSpecification" => new AsNoTrackingGetDeletedSubCategoryByIdSpecification(parameters[0]),
            "AsNoTrackingGetSubCategoryByNameARSpecification" => new AsNoTrackingGetSubCategoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetSubCategoryByNameDESpecification" => new AsNoTrackingGetSubCategoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetSubCategoryByNameENSpecification" => new AsNoTrackingGetSubCategoryByNameENSpecification(parameters[0]),
            "AsNoTrackingPaginateUnDeletedSubCategories" => new AsNoTrackingPaginateUnDeletedSubCategories(parameters[0], parameters[1], parameters[2], parameters[3]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Trip> CreateTripSpecifications(Type type, params dynamic[] parameters)
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
            "AsNoTrackingPaginateUnDeletedTripsSpecification" => new AsNoTrackingPaginateUnDeletedTripsSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedTripByIdSpecification" => new AsTrackingGetDeletedTripByIdSpecification(parameters[0]),
            "AsTrackingGetTripByIdSpecification" => new AsTrackingGetTripByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
}

