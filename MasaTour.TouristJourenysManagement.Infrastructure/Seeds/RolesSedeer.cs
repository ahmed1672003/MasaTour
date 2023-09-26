using MasaTour.TouristTripsManagement.Infrastructure.Enums;

namespace MasaTour.TouristTripsManagement.Infrastructure.Seeds;
public static class RolesSedeer
{
    public static async Task SeedRolesAsync(IUnitOfWork context)
    {
        if (await context.Roles.AnyAsync())
            return;

        await context.Identity.RoleManager.CreateAsync(new Role() { Name = Roles.SuperAdmin.ToString() });
        await context.Identity.RoleManager.CreateAsync(new Role() { Name = Roles.Admin.ToString() });
        await context.Identity.RoleManager.CreateAsync(new Role() { Name = Roles.Basic.ToString() });
    }
}
