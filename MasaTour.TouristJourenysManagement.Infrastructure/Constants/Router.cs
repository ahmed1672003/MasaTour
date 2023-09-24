namespace MasaTour.TouristJourenysManagement.Infrastructure.Constants;
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
    }

    public static class User
    {
        private const string UserPrefix = ApiPrefix + "user/";
        public const string UpdateUser = UserPrefix + "update-user";
        public const string GetUserById = UserPrefix + "get-user-by-id";
        public const string GetAllUsers = UserPrefix + "get-all-users";
        public const string MakeUserHidden = UserPrefix + "make-user-hidden-by-id";
        public const string MakeUserVisible = UserPrefix + "make-user-visible-by-id";
        public const string DeleteAllUsers = UserPrefix + "delete-all-users";
    }
}
