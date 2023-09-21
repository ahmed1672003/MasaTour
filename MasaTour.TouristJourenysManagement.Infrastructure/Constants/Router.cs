namespace MasaTour.TouristJourenysManagement.Infrastructure.Constants;
public static class Router
{
    public const string Api = "api/";
    public const string ApiVersion = "v1/";
    public const string ApiPrefix = Api + ApiVersion;
    public static class User
    {
        private const string UserPrefix = ApiPrefix + "users/";
        public const string AddUser = UserPrefix + "register-user";
        public const string GetAllUsers = UserPrefix + "get-all-users";
    }
}
