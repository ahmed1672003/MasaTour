namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
public interface IIdentityRepository : ITransientLifetime
{
    //IUserStore<User> UserStore { get; }
    //IUserEmailStore<User> UserEmailStore { get; }
    UserManager<User> UserManager { get; }
    SignInManager<User> SignInManager { get; }
    RoleManager<Role> RoleManager { get; }
}
