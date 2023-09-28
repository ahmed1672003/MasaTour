namespace MasaTour.TouristTripsManagement.Infrastructure.Constants;
public static class EndPoints
{
    public static class Auth
    {
        public static class AddUser
        {
            public const string OperationId = "664C7BF0-427E-4EA2-A1D4-151E236FBC1F";
            public const string Summary = "Register New User | (email, userName and phoneNumber) Are Unique | Allowed For Anonymous";
            public const string Description = "<b>On Success: ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies | User Will Be Assigned To Basic Role" +
                                   "</br></br> gender  { Male[0] Female[1] Other[2] UnKnown[3] }</b>";
        }

        public static class LoginUser
        {
            public const string OperationId = "134AA6CE-45FA-4115-9257-12F3A0BC3A1C";
            public const string Summary = "Login User | (email, password) Are Required | Allowed For Anonymous";
            public const string Description =
            "<b>" +
                    "On Success ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) Will Be Sent With Response In Cookies" +
                "</br></br> UserName: ahmedadel1672003 | Password: 123 (SuperAdmin)" +
                "</br></br> UserName: ahmedadel112019 | Password: 123 (Admin)" +
                "</br></br> UserName: ahmedadel1122003 | Password: 123 (Basic)" +
            "</b>";
        }

        public static class RefreshUserToken
        {
            public const string OperationId = "263F34DA-D6FE-4782-B4D8-D4BE013C5588";
            public const string Summary = "Refresh Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies | Allowed For Basic, Admin And SuperAdmin";
            public const string Description = "" +
                "<b>" +
                "On Success ( refreshToken ) Will Be Updated By Response In Cookies" +
                "</b>";
        }

        public static class RevokeUserToken
        {
            public const string OperationId = "8DF7BEDD-4B66-45B8-AF13-253599D1247D";
            public const string Summary = "Revoke Token For User | If You Will Not Send Body, Server Will Read ( JWT,RefreshToken ) From Cookies | Allowed For Basic, Admin And SuperAdmin";
            public const string Description =
                "<b>" +
                    "On Success Server Will Be Delete ( jwt, refreshToken, jwtExpirationDate, refreshJwtExpirationDate ) From Cookies" +
                "</b>";
        }

        public static class ChangePassword
        {
            public const string OperationId = "F76D3FF3-8ACA-488D-8FF0-6E0A5AE46CA1";
            public const string Summary = "Change Password | You Can Send Email Or User Name | Allowed For Basic, Admin And SuperAdmin";
            public const string Description =
                "<b>" +
                    "data Will Be Null In Response" +
                "</b>";
        }

        public static class ConfirmEmail
        {
            public const string OperationId = "4FBC7085-62B3-4753-9AAC-161EA4B65D15";
            public const string Summary = "Confirm Email | Allowed For Anonymous";
            public const string Description =
                "<b>" +
                    "data Will Be Null In Response" +
                "</b>";
        }
    }
    public static class User
    {
        public static class UpdateUser
        {
            public const string OperationId = "98962269-94EE-42D7-AC6F-48483D1FA289";
            public const string Summary = "Update User | (UserName) Is Unique | User Name Can Not Be Duplicated With Another User | Allowed For Basic, Admin, SuperAdmin";
            public const string Description =
                "<b>" +
                    "OnSuccess (New Data Will Be Retrieved)" +
                    "</br></br> nationality  Egyptian[0] Other[1] " +
                "</b>";
        }
        public static class GetUserById
        {
            public const string OperationId = "F6971800-455A-4877-B17E-E277EC5AEFC7";
            public const string Summary = "Get User By Id | Allowed For Basic, Admin, SuperAdmin";
            public const string Description = "<b>userId length must be equal 36</b>";
        }
        public static class GetAllUsers
        {
            public const string OperationId = "732A3F62-B9CD-4A2D-AE8E-CE8CD468168A";
            public const string Summary = "Get All Users From Server | This Endpoint Used For BackEnd Developer Only | Allowed For SuperAdmin Only";
            public const string Description =
                "<b>" +
                    "Return All Deleted And UnDeleted Users" +
                "</b>";
        }
        public static class DeleteUserById
        {
            public const string OperationId = "0B70CA81-86D9-4C34-9131-04523FCFD35C";
            public const string Summary = "Make User Hidden By Id From Server | Allowed For Admin, SuperAdmin Only";
            public const string Description =
                "<b>" +
                    "This Endpoint Mark At User (IsDeleted = true) And User Will Not Be Retrieved Any Time" +
                "</b>";
        }
        public static class UndoDeleteUserById
        {
            public const string OperationId = "1FEA8E1D-B136-4AAE-B6F9-7767DE555F2D";
            public const string Summary = "Make User Visible By Id From Server | Allowed For Admin, SuperAdmin Only";
            public const string Description =
                "<b>" +
                    "This Endpoint Mark At User (IsDeleted = false) And User Will Be Retrieved Again" +
                "</b>";
        }
        public static class DeleteAllUsers
        {
            public const string OperationId = "9DD5608A-00A0-4B08-B91D-C72E326F079F";
            public const string Summary = "Delete All Users From Server | This Endpoint Used For BackEnd Developer Only | Allowed For SuperAdmin Only";
            public const string Description =
                "<b>" +
                    "This Endpoint Created To Help BackEnd Developer At Development Phase Only" +
                "</b>";
        }
    }
    public static class Category
    {
        public static class AddCategory
        {
            public const string OperationId = "64E21296-7437-446B-9D64-2DCA87103157";
            public const string Summary = "Add New Category | Allowed For SuperAdmin And Admin";
            public const string Description =
                "<b>" +
                "If nameAr or nameDE or nameEN are Duplicated Will Send Bad Request" +
                "</b>";
        }

        public static class UpdateCategory
        {
            public const string OperationId = "0B5B4339-A263-4465-AE1A-66DC4C0D3AA5";
            public const string Summary = "Update Category By Id | Allowed For SuperAdmin And Admin";
            public const string Description =
                "<b>" +
                "If nameAr or nameDE or nameEN are Duplicated Will Send Bad Request" +
                "</b>";
        }

        public static class DeleteCategoryById
        {
            public const string OperationId = "3BA9D0AF-8E1E-49FC-9FA9-ED89C4EAE7C5";
            public const string Summary = "Delete Category By Id | Allowed For SuperAdmin And Admin";
            public const string Description =
                "<b>" +
                "This Endpoint Mark At User (IsDeleted = true) And User Will Not Be Retrieved Any Time" +
                "</b>";
        }
        public static class UndoDeleteCategoryById
        {
            public const string OperationId = "126E9D51-3238-4398-9D65-30075348239C";
            public const string Summary = "Undo Delete Category By Id | Allowed For SuperAdmin And Admin";
            public const string Description =
                "<b>" +
                  "This Endpoint Mark At User (IsDeleted = false) And User Will Be Retrieved Again" +
                "</b>";
        }
        public static class GetCategoryById
        {
            public const string OperationId = "6C810EF7-D50F-43C9-8DB9-A1DA3CDA913F";
            public const string Summary = "Get Category By Id | Allowed For Anonymous";
            public const string Description =
                "<b>" +
                  "Get Category By Id" +
                "</b>";
        }
        public static class GetAllCategories
        {
            public const string OperationId = "51C25943-A3FC-40FE-A4E3-2DEC5D682C72";
            public const string Summary = "Get All Categories | Allowed For Admin And SuperAdmin";
            public const string Description =
                "<b>" +
                  "Get All UnDeleted And Deleted Categories" +
                "</b>";
        }
        public static class GetAllDeletedCategories
        {
            public const string OperationId = "51C25943-A3FC-40FE-A4E3-2DEC5D682C721";
            public const string Summary = "Get All Deleted Categories | Allowed For Admin And SuperAdmin";
            public const string Description = "";
        }
        public static class GetAllUnDeletedCategories
        {
            public const string OperationId = "51C25943-A3FC-40FE-A4E3-2DEC5D682C723";
            public const string Summary = "Get All UnDeleted Categories | Allowed For Anonymous";
            public const string Description = "";
        }
        public static class PaginateUnDeletedCategories
        {
            public const string OperationId = "A765CF7A-43B6-47EB-91ED-2990DAECAE49";
            public const string Summary = "Paginate UnDeleted Categories | Allowed For Anonymous";
            public const string Description =
                "<b>" +
                  "</br></br> pageNumber Default Value = 1" +
                  "</br></br> pageSize   Default Value = 10" +
                  "</br></br> orderBy    Default Value = 4 , Id[0] , NameAR[1] , NameEN[2] , NameDE[3] , CreatedAt[4]" +
                "</b>";
        }
        public static class PaginateDeletedCategories
        {
            public const string OperationId = "CA60B5AE-5475-4884-A008-A26D81F68527";
            public const string Summary = "Paginate Deleted Categories | Allowed For SuperAdmin And Admin";
            public const string Description =
                "<b>" +
                  "</br></br> pageNumber Default Value = 1" +
                  "</br></br> pageSize   Default Value = 10" +
                  "</br></br> orderBy    Default Value = 4 , Id[0] , NameAR[1] , NameEN[2] , NameDE[3] , CreatedAt[4]" +
                "</b>";
        }
    }

    public static class Trip
    {

    }
}
