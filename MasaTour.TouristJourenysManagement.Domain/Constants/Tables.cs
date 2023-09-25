namespace MasaTour.TouristJourenysManagement.Domain.Constants;
public static class Tables
{
    public static class Identity
    {
        public const string Users = "Users";
        public const string Roles = "Roles";
        public const string RoleClaims = "RoleClaims";
        public const string UserClaims = "UserClaims";
        public const string UserJWTs = "UserJWTs";
        public const string UserLogins = "UserLogins";
        public const string UserRolesMappers = "UsersRolesMappers";
        public const string UserTokens = "UserTokens";
    }
    public const string Journeys = "Journeys";
    public const string Catgeories = "Catgeories";
    public const string CategoriesJourneysMappers = "CategoriesJourneysMapper";
}
