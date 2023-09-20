﻿using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
public class IdentityRepository : IIdentityRepository
{
    public IdentityRepository(
        IUserStore<User> userStore,
        IUserEmailStore<User> userEmailStore,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<Role> roleManager)
    {
        UserStore = userStore;
        UserEmailStore = userEmailStore;
        UserManager = userManager;
        SignInManager = signInManager;
        RoleManager = roleManager;
    }
    public IUserStore<User> UserStore { get; }
    public IUserEmailStore<User> UserEmailStore { get; }
    public UserManager<User> UserManager { get; }
    public SignInManager<User> SignInManager { get; }
    public RoleManager<Role> RoleManager { get; }
}
