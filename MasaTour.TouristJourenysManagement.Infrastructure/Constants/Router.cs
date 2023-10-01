namespace MasaTour.TouristTripsManagement.Infrastructure.Constants;
public static class Router
{
    private const string Api = "api/";
    private const string ApiVersion = "v1/";
    private const string ApiPrefix = Api + ApiVersion;
    public static class Auth
    {
        private const string AuthPrefix = ApiPrefix + "auth/";
        public const string AddUser = AuthPrefix + "register-user";
        public const string LoginUser = AuthPrefix + "login-user";
        public const string RefreshToken = AuthPrefix + "refresh-token";
        public const string RevokeToken = AuthPrefix + "revoke-token";
        public const string ChangePassword = AuthPrefix + "change-password";
        public const string ConfirmeEmail = AuthPrefix + "confirme-email";
    }

    public static class User
    {
        private const string UserPrefix = ApiPrefix + "user/";
        public const string UpdateUser = UserPrefix + "update-users";
        public const string GetUserById = UserPrefix + "get-user-by-id";
        public const string GetAllUsers = UserPrefix + "get-all-users";
        public const string DeleteUserById = UserPrefix + "delete-user-by-id";
        public const string UndoDeleteUserById = UserPrefix + "undo-delete-user-by-id";
        public const string DeleteAllUsers = UserPrefix + "delete-all-users";
    }

    public static class Category
    {
        private const string CategoryPrefix = ApiPrefix + "categories/";
        public const string AddCategory = CategoryPrefix + "add-category";
        public const string UpdateCategory = CategoryPrefix + "update-category";
        public const string DeleteCategoryById = CategoryPrefix + "delete-category-by-id";
        public const string UndoDeleteCategoryById = CategoryPrefix + "undo-delete-category-by-id";
        public const string GetCategoryById = CategoryPrefix + "get-category-by-id";
        public const string GetAllCategories = CategoryPrefix + "get-all-categories";
        public const string GetAllDeletedCategories = CategoryPrefix + "get-all-deleted-categories";
        public const string GetAllUnDeletedCategories = CategoryPrefix + "get-all-un-deleted-categories";
        public const string PaginateUnDeletedCategories = CategoryPrefix + "paginate-all-un-deleted-categories";
        public const string PaginateDeletedCategories = CategoryPrefix + "paginate-all-deleted-categories";
    }

    public static class SubCategory
    {
        private const string CategoryPrefix = ApiPrefix + "sub-categories/";
        public const string AddSubCategory = CategoryPrefix + "add-sub-category";
        public const string UpdateSubCategory = CategoryPrefix + "update-sub-category";
        public const string DeleteSubCategoryById = CategoryPrefix + "delete-sub-category-by-id";
        public const string UndoDeleteSubCategoryById = CategoryPrefix + "undo-delete-sub-category-by-id";
        public const string GetSubCategoryById = CategoryPrefix + "get-sub-category-by-id";
        public const string GetAllSubCategories = CategoryPrefix + "get-all-sub-categories";
        public const string GetAllDeletedSubCategories = CategoryPrefix + "get-all-deleted-sub-categories";
        public const string GetAllUnDeletedSubCategories = CategoryPrefix + "get-all-un-deleted-sub-categories";
        public const string PaginateUnDeletedSubCategories = CategoryPrefix + "paginate-all-un-deleted-sub-categories";
        public const string PaginateDeletedSubCategories = CategoryPrefix + "paginate-all-deleted-sub-categories";
    }

    public static class Trip
    {
        private const string TripPrefix = ApiPrefix + "trips/";
        public const string AddTrip = TripPrefix + "add-trip";
        public const string UpdateTrip = TripPrefix + "update-trip";
        public const string DeleteTripById = TripPrefix + "delete-trip-by-id";
        public const string UndoDeleteTripById = TripPrefix + "undo-delete-trip-by-id";
        public const string GetTripById = TripPrefix + "get-trip-by-id";
        public const string GetTripById_Mandatories_Images = TripPrefix + "get-trip-by-id_mandatories_images";
        public const string GetAllActiveTrips = TripPrefix + "get-all-active-trips";
        public const string GetAllNotActiveTrips = TripPrefix + "get-all-not-active-trips";
        public const string GetAllTrips = TripPrefix + "get-all-trips";
        public const string GetAllDeletedTrips = TripPrefix + "get-all-deleted-trips";
        public const string GetAllUnDeletedTrips = TripPrefix + "get-all-un-deleted-trips";
        public const string PaginateUnDeletedTrips = TripPrefix + "paginate-all-un-deleted-trips";
        public const string PaginateDeletedTrips = TripPrefix + "paginate-all-deleted-trips";
    }

    public static class Mandatory
    {
        private const string MandatoryPrefix = ApiPrefix + "mandatorys/";
        public const string AddMandatory = MandatoryPrefix + "add-mandatory";
        public const string UpdateMandatory = MandatoryPrefix + "update-mandatory";
        public const string DeleteMandatoryById = MandatoryPrefix + "delete-mandatory-by-id";
        public const string UndoDeleteMandatoryById = MandatoryPrefix + "undo-delete-mandatory-by-id";
        public const string GetMandatoryById = MandatoryPrefix + "get-mandatory-by-id";
        public const string GetAllMandatories = MandatoryPrefix + "get-all-mandatories";
        public const string GetAllDeletedMandatories = MandatoryPrefix + "get-all-deleted-mandatories";
        public const string GetAllUnDeletedMandatories = MandatoryPrefix + "get-all-un-deleted-mandatories";
        public const string PaginateUnDeletedMandatories = MandatoryPrefix + "paginate-all-un-deleted-mandatories";
        public const string PaginateDeletedMandatories = MandatoryPrefix + "paginate-all-deleted-mandatories";
    }

    public static class Image
    {
        private const string ImagePrefix = ApiPrefix + "image/";
        public const string AddImage = ImagePrefix + "add-image";
        public const string AddImages = ImagePrefix + "add-images";
        public const string DeleteImage = ImagePrefix + "delete-image";
        public const string DeleteImages = ImagePrefix + "delete-images";
        public const string GetImageById = ImagePrefix + "get-by-id";
        public const string GetAllImages = ImagePrefix + "get-all";
        public const string PaginateImages = ImagePrefix + "paginate-all-images";
    }

    public static class TripPhase
    {

    }
}
