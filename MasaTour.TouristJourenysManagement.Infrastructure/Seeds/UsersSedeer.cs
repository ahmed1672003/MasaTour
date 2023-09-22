using MasaTour.TouristJourenysManagement.Domain.Enums;
using MasaTour.TouristJourenysManagement.Infrastructure.Enums;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Seeds;
public static class UsersSedeer
{
    public static async Task SeedSuperAdminAsync(IUnitOfWork context, ISpecificationsFactory specificationsFactory)
    {
        var superAdmin = new User
        {
            UserName = "ahmedadel1672003",
            Email = "ahmedadel1672003@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            ImgSrc = "path",
            PhoneNumber = "01018856093",
            Nationality = Nationality.Egyptian,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        var emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), superAdmin.Email);
        var phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(PhoneNumberIsExistSpecification), superAdmin.PhoneNumber);
        // check if email of phone number are not
        if ((await context.Users.AnyAsync(emailIsExistSpec) || await context.Users.AnyAsync(phoneNumberIsExisttSpec)))
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
            UserName = "ahmedadel112019",
            Email = "ahmedadel112019@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            ImgSrc = "path",
            PhoneNumber = "01280755031",
            Nationality = Nationality.Egyptian,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };

        var emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), admin.Email);
        var phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(PhoneNumberIsExistSpecification), admin.PhoneNumber);
        // check if email of phone number are not
        if ((await context.Users.AnyAsync(emailIsExistSpec) || await context.Users.AnyAsync(phoneNumberIsExisttSpec)))
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
            UserName = "ahmedadel1122003",
            Email = "ahmedadel1122003@gmail.com",
            FirstName = "Ahmed",
            LastName = "Adel",
            ImgSrc = "path",
            PhoneNumber = "01280755041",
            Nationality = Nationality.Egyptian,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };

        var emailIsExistSpec = specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), basic.Email);
        var phoneNumberIsExisttSpec = specificationsFactory.CreateUserSpecifications(typeof(PhoneNumberIsExistSpecification), basic.PhoneNumber);
        // check if email of phone number are not
        if ((await context.Users.AnyAsync(emailIsExistSpec) || await context.Users.AnyAsync(phoneNumberIsExisttSpec)))
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
