

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
            _ => throw new InvalidOperationException("Create User Specification Exception!")
        };
    }
    public ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetRolesByNameSpecification" => new AsNoTrackingGetRolesByNameSpecification(parameters[0]),
            _ => throw new InvalidOperationException("Create Role Specification Exception!")
        };
    }
    public ISpecification<UserJWT> CreateUserJWTSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingJwtIsExistSpecification" => new AsNoTrackingJwtIsExistSpecification(parameters[0], parameters[1]),
            "AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification" => new AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException("Create UserJWT Specification Exception!")
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
            "AsNoTrackingPaginateDeletedCategoriesSpecification" => new AsNoTrackingPaginateDeletedCategoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
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
            _ => throw new InvalidOperationException("Create Category Specification Exception!")
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
            "AsTrackingGetSubCategoryByIdSpecification" => new AsTrackingGetSubCategoryByIdSpecification(parameters[0]),
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
            "AsNoTrackingPaginateUnDeletedSubCategoriesSpecification" => new AsNoTrackingPaginateUnDeletedSubCategoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateDeletedSubCategoriesSpecification" => new AsNoTrackingPaginateDeletedSubCategoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedSubCategoryById_Trips_Specification" => new AsTrackingGetDeletedSubCategoryById_Trips_Specification(parameters[0]),
            "AsTrackingGetDeletedSubCategoryByIdSpecification" => new AsTrackingGetDeletedSubCategoryByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException("Create SubCategory Specification Exception!")
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
            "AsNoTrackingGetTripById_Mandatories_Images_Specification" => new AsNoTrackingGetTripById_Mandatories_Images_Specification(parameters[0]),
            "AsNoTrackingGetTripById_Images_Specification" => new AsNoTrackingGetTripById_Images_Specification(parameters[0]),
            "AsNoTrackingPaginateUnDeletedTripsSpecification" => new AsNoTrackingPaginateUnDeletedTripsSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateDeletedTripsSpecification" => new AsNoTrackingPaginateDeletedTripsSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedTripByIdSpecification" => new AsTrackingGetDeletedTripByIdSpecification(parameters[0]),
            "AsTrackingGetTripByIdSpecification" => new AsTrackingGetTripByIdSpecification(parameters[0]),
            "AsTrackingGetTripById_TripPhases_Specification" => new AsTrackingGetTripById_TripPhases_Specification(parameters[0]),
            _ => throw new InvalidOperationException("Create Trip Specification Exception!")
        };
    }
    public ISpecification<Mandatory> CreateMandatorySpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedDeletedMandatoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedDeletedMandatoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedDeletedMandatoryByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedMandatoryByNameARSpecification" => new AsNoTrackingCheckDuplicatedMandatoryByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedMandatoryByNameDESpecification" => new AsNoTrackingCheckDuplicatedMandatoryByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedMandatoryByNameENSpecification" => new AsNoTrackingCheckDuplicatedMandatoryByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingetGetMandatoryByIdSpecification" => new AsNoTrackingetGetMandatoryByIdSpecification(parameters[0]),
            "AsNoTrackingGetAllDeletedMandatoriesSpecification" => new AsNoTrackingGetAllDeletedMandatoriesSpecification(),
            "AsNoTrackingGetAllMandatoriesSpecification" => new AsNoTrackingGetAllMandatoriesSpecification(),
            "AsNoTrackingGetDeletedMandatoryByIdSpecification" => new AsNoTrackingGetDeletedMandatoryByIdSpecification(parameters[0]),
            "AsNoTrackingGetDeletedMandatoryByNameARSpecification" => new AsNoTrackingGetDeletedMandatoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetDeletedMandatoryByNameDESpecification" => new AsNoTrackingGetDeletedMandatoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetDeletedMandatoryByNameENSpecification" => new AsNoTrackingGetDeletedMandatoryByNameENSpecification(parameters[0]),
            "AsNoTrackingGetMandatoryByNameARSpecification" => new AsNoTrackingGetMandatoryByNameARSpecification(parameters[0]),
            "AsNoTrackingGetMandatoryByNameDESpecification" => new AsNoTrackingGetMandatoryByNameDESpecification(parameters[0]),
            "AsNoTrackingGetMandatoryByNameENSpecification" => new AsNoTrackingGetMandatoryByNameENSpecification(parameters[0]),
            "AsNoTrackingPaginateDeletedMandatoriesSpecification" => new AsNoTrackingPaginateDeletedMandatoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateUnDeletedMandatoriesSpecification" => new AsNoTrackingPaginateUnDeletedMandatoriesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetDeletedMandatoryById_TripMandatoryMapper_Specification" => new AsTrackingGetDeletedMandatoryById_TripMandatoryMapper_Specification(parameters[0]),
            "AsTrackingGetDeletedMandatoryByIdSpecification" => new AsTrackingGetDeletedMandatoryByIdSpecification(parameters[0]),
            "AsTrackingGetMandatoryByIdSpecification" => new AsTrackingGetDeletedMandatoryByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException("Create Mandatory Specification Exception!")
        };
    }
    public ISpecification<Image> CreateImageSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetImageByIdSpecification" => new AsNoTrackingGetImageByIdSpecification(parameters[0]),
            "AsNoTrackingPaginateImagesSpecification" => new AsNoTrackingPaginateImagesSpecification(parameters[0], parameters[1], parameters[2]),
            "AsTrackingGetImagesByIdsSpecification" => new AsTrackingGetImagesByIdsSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<TripImageMapper> CreateTripImageMapperSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetTripImagesMappersByCompositeKeySpecification" => new AsNoTrackingGetTripImagesMappersByCompositeKeySpecification(parameters[0], parameters[1]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<TripPhase> CreateTripPhaseSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetTripPhaseByTripIdSpecification" => new AsNoTrackingGetTripPhaseByTripIdSpecification(parameters[0]),
            "AsNoTrackingGetAllTripPhasesByTripIdSpecification" => new AsNoTrackingGetAllTripPhasesByTripIdSpecification(parameters[0]),
            "AsNoTrackingGetTripPhaseByIdSpecification" => new AsNoTrackingGetTripPhaseByIdSpecification(parameters[0]),
            "AsTrackingGetTripPhaseSpecification" => new AsTrackingGetTripPhaseSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<Comment> CreateCommentsSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingGetAllCommentsByTripIdSpecification" => new AsNoTrackingGetAllCommentsByTripIdSpecification(parameters[0]),
            "AsNoTrackingGetCommentByIdSpecification" => new AsNoTrackingGetCommentByIdSpecification(parameters[0]),
            "AsTrackingGetCommentByIdSpecification" => new AsTrackingGetCommentByIdSpecification(parameters[0]),
            "AsTrackingGetDeletedCommentByIdSpecification" => new AsTrackingGetDeletedCommentByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException()
        };
    }
    public ISpecification<TransportationClass> CreateTransporationClassesSpecifications(Type type, params dynamic[] parameters)
    {
        return type.Name switch
        {
            "AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpecification" => new AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpecification" => new AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpecification" => new AsNoTrackingCheckDuplicatedDeletedTransportationClassByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedTransportationClassByNameARSpecification" => new AsNoTrackingCheckDuplicatedTransportationClassByNameARSpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedTransportationClassByNameDESpecification" => new AsNoTrackingCheckDuplicatedTransportationClassByNameDESpecification(parameters[0], parameters[1]),
            "AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification" => new AsNoTrackingCheckDuplicatedTransportationClassByNameENSpecification(parameters[0], parameters[1]),
            "AsNoTrackingGetDeletedTransportationClassByIdSpecification" => new AsNoTrackingGetDeletedTransportationClassByIdSpecification(parameters[0]),
            "AsNoTrackingGetDeletedTransportationClassByNameARSpecification" => new AsNoTrackingGetDeletedTransportationClassByNameARSpecification(parameters[0]),
            "AsNoTrackingGetDeletedTransportationClassByNameDESpecification" => new AsNoTrackingGetDeletedTransportationClassByNameDESpecification(parameters[0]),
            "AsNoTrackingGetDeletedTransportationClassByNameENSpecification" => new AsNoTrackingGetDeletedTransportationClassByNameENSpecification(parameters[0]),
            "AsNoTrackingGetTransportationByIdSpecification" => new AsNoTrackingGetTransportationByIdSpecification(parameters[0]),
            "AsNoTrackingGetTransportationClassByNameARSpecification" => new AsNoTrackingGetTransportationClassByNameARSpecification(parameters[0]),
            "AsNoTrackingGetTransportationClassByNameENSpecification" => new AsNoTrackingGetTransportationClassByNameENSpecification(parameters[0]),
            "AsNoTrackingGetTransportationClassByNameDESpecification" => new AsNoTrackingGetTransportationClassByNameDESpecification(parameters[0]),
            "AsNoTrackingGetAllTranspotationClassesSpecification" => new AsNoTrackingGetAllTranspotationClassesSpecification(),
            "AsNoTrackingGetAllDeletedTranspotationClassesSpecification" => new AsNoTrackingGetAllDeletedTranspotationClassesSpecification(),
            "AsNoTrackingPaginateDeletedTransportationClassesSpecification" => new AsNoTrackingPaginateDeletedTransportationClassesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsNoTrackingPaginateUnDeletedTransportationClassesSpecification" => new AsNoTrackingPaginateUnDeletedTransportationClassesSpecification(parameters[0], parameters[1], parameters[2], parameters[3]),
            "AsTrackingGetTransportationClassByIdSpecification" => new AsTrackingGetTransportationClassByIdSpecification(parameters[0]),
            "AsTrackingGetDeletedTransportationClassByIdSpecification" => new AsTrackingGetDeletedTransportationClassByIdSpecification(parameters[0]),
            _ => throw new InvalidOperationException(),
        };
    }
}

