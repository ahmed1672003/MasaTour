namespace MasaTour.TouristJourenysManagement.Infrastructure.Constants;
public static class EndPoints
{
    public static class Auth
    {
        public static class AddUser
        {
            public const string OperationId = "664C7BF0-427E-4EA2-A1D4-151E236FBC1F";
            public const string Summary = "Register New User | (email, userName and phoneNumber) Are Unique | Allowed For Anonymous";
            public const string Description = "On Success: ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies | User Will Be Assigned To Basic Role" +
                                   "</br></br> nationality  Egyptian[0] Other[1] </hr>" +
                                   "</br></br> gender  Male[0] Female[1] Other[2] UnKnown[3]";
        }

        public static class LoginUser
        {
            public const string OperationId = "134AA6CE-45FA-4115-9257-12F3A0BC3A1C";
            public const string Summary = "Login User | (email, password) Are Required | Allowed For Anonymous";
            public const string Description = "On Success ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies" +
                                   "</br></br> UserName: ahmedadel1672003 | Password: 123 (SuperAdmin)" +
                                   "</br></br> UserName: ahmedadel112019 | Password: 123 (Admin)" +
                                   "</br></br> UserName: ahmedadel1122003 | Password: 123 (Basic)";
        }

        public static class RefreshUserToken
        {
            public const string OperationId = "263F34DA-D6FE-4782-B4D8-D4BE013C5588";
            public const string Summary = "Refresh Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies | Allowed For Basic, Admin And SuperAdmin";
            public const string Description = "On Success ( refreshToken ) Will Be Updated By Response In Cookies";
        }

        public static class RevokeUserToken
        {
            public const string OperationId = "8DF7BEDD-4B66-45B8-AF13-253599D1247D";
            public const string Summary = "Revoke Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies | Allowed For Basic, Admin And SuperAdmin";
            public const string Description = "On Success Server Will Be Delete ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) From Cookies";
        }

        public static class ChangePassword
        {
            public const string OperationId = "F76D3FF3-8ACA-488D-8FF0-6E0A5AE46CA1";
            public const string Summary = "Change Password | You Can Send Email Or User Name | Allowed For Basic, Admin And SuperAdmin";
            public const string Description = "Property (data) Will Be Null In Response Body";
        }

        public static class GetAllUsers
        {
            public const string OperationId = "732A3F62-B9CD-4A2D-AE8E-CE8CD468168A";
            public const string Summary = "Get All Users From Server | This Endpoint Used For BackEnd Developer Only | Allowed For SuperAdmin Only";
            public const string Description = "This Endpoint Created To Help BackEnd Developer At Development Phase Only";
        }

        public static class DeleteAllUsers
        {
            public const string OperationId = "732A3F62-B9CD-4A2D-AE8E-CE8CD468168A";
            public const string Summary = "Delete All Users From Server | This Endpoint Used For BackEnd Developer Only | Allowed For SuperAdmin Only";
            public const string Description = "This Endpoint Created To Help BackEnd Developer At Development Phase Only";
        }
    }
    public static class User
    {
        public static class UpdateUser
        {
            public const string OperationId = "98962269-94EE-42D7-AC6F-48483D1FA289";
            public const string Summary = "Update User | (UserName) Is Unique | User Name Can Not Be Duplicated With Another User | Allowed For Basic, Admin, SuperAdmin";
            public const string Description = "OnSuccess (New Data Will Be Rerieved)" +
                                   "</br></br> nationality  Egyptian[0] Other[1] </hr>";
        }
        public static class GetUserById
        {
            public const string OperationId = "F6971800-455A-4877-B17E-E277EC5AEFC7";
            public const string Summary = "Get User By Id | Allowed For Basic, Admin, SuperAdmin";
            public const string Description = "<b>userId length must be equal 36</b>";
        }
    }
}
