namespace MasaTour.TouristJourenysManagement.Infrastructure.Constants;
public static class Router
{
    public const string Api = "api/";
    public const string ApiVersion = "v1/";
    public const string ApiPrefix = Api + ApiVersion;
    public static class Auth
    {
        private const string UserPrefix = ApiPrefix + "auth/";
        public const string AddUser = UserPrefix + "register-user";
        public const string GetAllUsers = UserPrefix + "get-all-users";
        public const string DeleteAllUsers = UserPrefix + "delete-all-users";
        public const string LoginUser = UserPrefix + "login-user";
        public const string RefreshToken = UserPrefix + "refresh-token";
        public const string RevokeToken = UserPrefix + "revoke-token";
        public const string ChangePassword = UserPrefix + "change-password";
    }
}
