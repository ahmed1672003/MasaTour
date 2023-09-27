﻿namespace MasaTour.TouristTripsManagement.Infrastructure.Constants;
public static class Router
{
    public const string Api = "api/";
    public const string ApiVersion = "v1/";
    public const string ApiPrefix = Api + ApiVersion;
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
        public const string UpdateUser = UserPrefix + "update-user";
        public const string GetUserById = UserPrefix + "get-user-by-id";
        public const string GetAllUsers = UserPrefix + "get-all-users";
        public const string DeleteUserById = UserPrefix + "delete-user-by-id";
        public const string UndoDeleteUserById = UserPrefix + "undo-delete-user-by-id";
        public const string DeleteAllUsers = UserPrefix + "delete-all-users";
    }

    public static class Category
    {
        private const string CategoryPrefix = ApiPrefix + "category/";
        public const string AddCategory = CategoryPrefix + "add-category";
        public const string UpdateCategory = CategoryPrefix + "update-category";
        public const string DeleteCategoryById = CategoryPrefix + "delete-category-by-id";
        public const string UndoDeleteCategoryById = CategoryPrefix + "undo-delete-category-by-id";
        public const string GetCategoryById = CategoryPrefix + "get-category-by-id";
        public const string GetAllCategories = CategoryPrefix + "get-all-categories";
        public const string GetAllDeletedCategories = CategoryPrefix + "get-all-deleted-categories";
        public const string GetAllUnDeletedCategories = CategoryPrefix + "get-all-un-deleted-categories";
        public const string PaginateCategories = CategoryPrefix + "paginate-categories";
    }

    public static class Trip
    {
        private const string TripPrefix = ApiPrefix + "trip/";
        public const string AddTrip = TripPrefix + "add-trip";
        public const string UpdateTrip = TripPrefix + "update-trip";
        public const string DeleteTripById = TripPrefix + "delete-trip-by-id";
        public const string UndoDeleteTripById = TripPrefix + "undo-delete-trip-by-id";
        public const string GetTripById = TripPrefix + "get-trip-by-id";
        public const string GetAllActiveTrips = TripPrefix + "get-all-active-trips";
        public const string GetAllNotActiveTrips = TripPrefix + "get-all-not-active-trips";
        public const string GetAllTrips = TripPrefix + "get-all-trips";
        public const string GetAllDeletedTrips = TripPrefix + "get-all-deleted-trips";
        public const string GetAllUnDeletedTrips = TripPrefix + "get-all-un-deleted-trips";
        public const string PaginateTrips = TripPrefix + "paginate-trips";
        public const string GetCurrenciesBasedOnUSD = TripPrefix + "get-all-currencies-based-on-usd";
    }
}
