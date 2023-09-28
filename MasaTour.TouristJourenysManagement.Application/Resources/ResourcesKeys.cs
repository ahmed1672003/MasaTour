namespace MasaTour.TouristTripsManagement.Application.Resources;
public static class ResourcesKeys
{
    public static class Shared
    {
        public const string BadRequest = "BadRequest";
        public const string NotFound = "NotFound";
        public const string InternalServerError = "InternalServerError";
        public const string Success = "Success";
        public const string Created = "Created";
        public const string UnAuthorized = "UnAuthorized";
        public const string Conflict = "Conflict";
    }

    public static class User
    {
        //public const string FirstNameCanNotBeNull = "FirstNameCanNotBeNull";
        //public const string LastNameNameCanNotBeNull = "LastNameNameCanNotBeNull";
        //public const string PhoneNumberCanNotBeNull = "PhoneNumberCanNotBeNull";
        //public const string EmailCanNotBeNull = "EmailCanNotBeNull";
        //public const string PasswordCanNotNull = "PasswordCanNotNull";
        //public const string ConfirmedPasswordCanNotBeNull = "ConfirmedPasswordCanNotBeNull";
        //public const string NationalityCanNotBeNull = "NationalityCanNotBeNull";
        public const string PasswordDoesNotMatchedWithConfilremdPassword = "PasswordDoesNotMatchedWithConfilremdPassword";
        public const string FiledLengthIsBiggerThanMaxLength = "FiledLengthIsBiggerThanMaxLength";
        public const string FiledLengthIsSmallerThanMinLength = "FiledLengthIsSmallerThanMinLength";
        public const string FiledCanNotBeEmpty = "FiledCanNotBeEmpty";
        public const string FiledCanNotBeNull = "FiledCanNotBeNull";
        public const string EmailNotValid = "EmailNotValid";
        public const string UserNameIsDuplicated = "UserNameIsDuplicated";
        public const string EmailIsDuplicated = "EmailIsDuplicated";
        public const string PhoneNumberIsDuplicated = "PhoneNumberIsDuplicated";
        public const string EmailIsExist = "EmailIsExist";
    }

    public static class Category
    {
        public const string FiledCanNotBeNull = "FiledCanNotBeNull";
        public const string FiledLengthIsBiggerThanMaxLength = "FiledLengthIsBiggerThanMaxLength";
        public const string FiledLengthIsSmallerThanMinLength = "FiledLengthIsSmallerThanMinLength";
        public const string FiledCanNotBeEmpty = "FiledCanNotBeEmpty";
    }

    public static class SubCategory
    {
        public const string FiledCanNotBeNull = "FiledCanNotBeNull";
        public const string FiledLengthIsBiggerThanMaxLength = "FiledLengthIsBiggerThanMaxLength";
        public const string FiledLengthIsSmallerThanMinLength = "FiledLengthIsSmallerThanMinLength";
        public const string FiledCanNotBeEmpty = "FiledCanNotBeEmpty";
    }

    public static class Trip
    {
        public const string FiledCanNotBeNull = "FiledCanNotBeNull";
        public const string FiledLengthIsBiggerThanMaxLength = "FiledLengthIsBiggerThanMaxLength";
        public const string FiledLengthIsSmallerThanMinLength = "FiledLengthIsSmallerThanMinLength";
        public const string FiledCanNotBeEmpty = "FiledCanNotBeEmpty";
    }

    public static class Mandatory
    {
        public const string FiledCanNotBeNull = "FiledCanNotBeNull";
        public const string FiledLengthIsBiggerThanMaxLength = "FiledLengthIsBiggerThanMaxLength";
        public const string FiledLengthIsSmallerThanMinLength = "FiledLengthIsSmallerThanMinLength";
        public const string FiledCanNotBeEmpty = "FiledCanNotBeEmpty";
    }
}
