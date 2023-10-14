using MasaTour.TouristTripsManagement.Domain.Enums;
using MasaTour.TouristTripsManagement.Infrastructure.Enums;

namespace MasaTour.TouristTripsManagement.Infrastructure.Seeds;
public static class UsersSedeer
{
    public static async Task SeedSuperAdminAsync(IUnitOfWork context, ISpecificationsFactory specificationsFactory)
    {
        var superAdmin = new User
        {
            Id = "C12791C9-1DAA-4A8D-B2BA-0055AA06DB34",
            UserName = "ahmedadel1672003",
            Email = "ahmedadel1672003@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            //ImgSrc = "path",
            PhoneNumber = "01018856093",
            Nationality = "Egyptian",
            Gender = Gender.Male,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        // check if email of phone number are not
        ISpecification<User> userIdIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingUserIdIsExistSpecification), superAdmin.Id);
        if (await context.Users.AnyAsync(userIdIsExistSpec))
            return;

        ISpecification<User> emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), superAdmin.Email);
        if (await context.Users.AnyAsync(emailIsExistSpec))
            return;

        ISpecification<User> phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingPhoneNumberIsExistSpecification), superAdmin.PhoneNumber);
        if ((await context.Users.AnyAsync(userIdIsExistSpec) || await context.Users.AnyAsync(emailIsExistSpec) || await context.Users.AnyAsync(phoneNumberIsExisttSpec)))
            return;

        // add user
        await context.Identity.UserManager.CreateAsync(superAdmin, "123");

        // assign roles for user
        await context.Identity.UserManager.AddToRolesAsync(superAdmin, new List<string>
        {
            Roles.SuperAdmin.ToString(),
            Roles.Admin.ToString(),
            Roles.Basic.ToString(),
        });
    }

    public static async Task SeedAdminAsync(IUnitOfWork context, ISpecificationsFactory specificationsFactory)
    {
        var admin = new User
        {
            Id = "E29D0D63-A4E9-4381-BD42-9821E8F267EE",
            UserName = "ahmedadel112019",
            Email = "ahmedadel112019@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            //ImgSrc = "path",
            PhoneNumber = "01280755031",
            Nationality = "Egyptian",
            Gender = Gender.Male,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        // check if email of phone number are not
        ISpecification<User> userIdIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingUserIdIsExistSpecification), admin.Id);
        if (await context.Users.AnyAsync(userIdIsExistSpec))
            return;

        ISpecification<User> emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), admin.Email);
        if (await context.Users.AnyAsync(emailIsExistSpec))
            return;

        ISpecification<User> phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingPhoneNumberIsExistSpecification), admin.PhoneNumber);
        if (await context.Users.AnyAsync(phoneNumberIsExisttSpec))
            return;

        // add user
        await context.Identity.UserManager.CreateAsync(admin, "123");

        // assign roles for user
        await context.Identity.UserManager.AddToRolesAsync(admin, new List<string>
        {
            Roles.Admin.ToString(),
            Roles.Basic.ToString(),
        });
    }

    public static async Task SeedBasicAsync(IUnitOfWork context, ISpecificationsFactory specificationsFactory)
    {
        var basic = new User
        {
            Id = "24553FC1-821A-437C-8541-41F065A52DFC",
            UserName = "ahmedadel1122003",
            Email = "ahmedadel1122003@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            //ImgSrc = "path",
            PhoneNumber = "01280755041",
            Nationality = "Egyptian",
            Gender = Gender.Male,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };

        // check if email of phone number are not
        ISpecification<User> userIdIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingUserIdIsExistSpecification), basic.Id);
        if (await context.Users.AnyAsync(userIdIsExistSpec))
            return;

        ISpecification<User> emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), basic.Email);
        if (await context.Users.AnyAsync(emailIsExistSpec))
            return;

        ISpecification<User> phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingPhoneNumberIsExistSpecification), basic.PhoneNumber);
        if (await context.Users.AnyAsync(phoneNumberIsExisttSpec))
            return;

        // add user
        await context.Identity.UserManager.CreateAsync(basic, "123");

        // assign roles for user
        await context.Identity.UserManager.AddToRolesAsync(basic, new List<string>
        {
            Roles.Basic.ToString(),
        });
    }
}
