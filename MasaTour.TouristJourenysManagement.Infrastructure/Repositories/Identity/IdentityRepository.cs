namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
public sealed class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<Role> roleManager)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
    }

    public UserManager<User> UserManager { get; }
    public SignInManager<User> SignInManager { get; }
    public RoleManager<Role> RoleManager { get; }

    public async Task<bool> ConfirmEmailAsync(string token, string userId, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(userId.Trim()) || string.IsNullOrEmpty(token.Trim()))
                return false;

            if (!await UserManager.Users.AnyAsync(user => user.Id.Equals(userId), cancellationToken))
                return false;

            User user = await UserManager.Users.FirstOrDefaultAsync(user => user.Id.Equals(user.Id), cancellationToken);

            var result = await UserManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
                return false;

            return true;
        }
        catch
        {
            return false;
        }
    }
}
