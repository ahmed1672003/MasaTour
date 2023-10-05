namespace MasaTour.TouristTripsManagement.Domain.Constants;
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
    public const string Categories = "Categories";
    public const string SubCategories = "SubCategories";
    public const string Trips = "Trips";
    public const string TripPhases = "TripPhases";
    public const string Mandatories = "Mandatories";
    public const string TripMandatoryMappers = "TripMandatoryMappers";
    public const string Images = "Images";
    public const string TripImageMapper = "TripImageMappers";
    public const string Comments = "Comments";
}
