namespace MasaTour.TouristJourenysManagement.Infrastructure.Constants;
public static class EndPoints
{
    public static class Auth
    {
        public static class AddUser
        {
            public const string OperationId = "664C7BF0-427E-4EA2-A1D4-151E236FBC1F";
            public const string Summary = "Register New User | (email, userName and phoneNumber) Are Unique";
            public const string Description = "On Success: ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies." +
                                   "</br></br> Nationality: Egyptian[0] & Other[1]";
        }

        public static class LoginUser
        {
            public const string OperationId = "134AA6CE-45FA-4115-9257-12F3A0BC3A1C";
            public const string Summary = "Login User | (email, password) Are Required ";
            public const string Description = "On Success ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies";

        }

        public static class RefreshUserToken
        {
            public const string OperationId = "263F34DA-D6FE-4782-B4D8-D4BE013C5588";
            public const string Summary = "Refresh Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies";
            public const string Description = "On Success ( refreshToken ) Will Be Updated By Response In Cookies";

        }

        public static class RevokeUserToken
        {
            public const string OperationId = "8DF7BEDD-4B66-45B8-AF13-253599D1247D";
            public const string Summary = "Revoke Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies";
            public const string Description = "On Success Server Will Be Delete ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) From Cookies";
        }

        public static class GetAllUsers
        {
            public const string OperationId = "732A3F62-B9CD-4A2D-AE8E-CE8CD468168A";
            public const string Summary = "Get All Users From Server | This Endpoint Used For BackEnd Developer Only";
            public const string Description = "This Endpoint Created To Help BackEnd Developer At Development Phase Only";
        }

        public static class DeleteAllUsers
        {
            public const string OperationId = "732A3F62-B9CD-4A2D-AE8E-CE8CD468168A";
            public const string Summary = "Delete All Users From Server | This Endpoint Used For BackEnd Developer Only";
            public const string Description = "This Endpoint Created To Help BackEnd Developer At Development Phase Only";
        }
    }
}
