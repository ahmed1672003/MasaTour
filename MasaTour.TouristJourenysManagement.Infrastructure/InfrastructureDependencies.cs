namespace MasaTour.TouristJourenysManagement.Infrastructure;
public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register DbContext Options
        services.AddDbContext<ITouristJourenysManagementDbContext, TouristJourenysManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MasaTour_TouristJourenysManagement"));
        }, ServiceLifetime.Transient);
        #endregion

        #region Register Identity 
        services.AddIdentity<User, Role>(options =>
        {
            #region Email Options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedAccount = false;
            #endregion

            #region Stores Options
            //options.Stores.ProtectPersonalData = true;
            #endregion

            #region Password Options
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 3;
            #endregion

            #region User Options
            options.User.RequireUniqueEmail = true;
            #endregion

            #region Lock Out Options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
            #endregion

        }).AddEntityFrameworkStores<TouristJourenysManagementDbContext>().AddDefaultTokenProviders().AddDefaultUI();
        #endregion

        #region Register Contracts Liftimes
        services
            .Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly()).AddClasses(c => c.AssignableTo<ITransientLifetime>()).AsImplementedInterfaces().WithTransientLifetime())
            .Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly()).AddClasses(c => c.AssignableTo<IScopeLifetime>()).AsImplementedInterfaces().WithScopedLifetime())
            .Scan(s => s.FromAssemblies(Assembly.GetExecutingAssembly()).AddClasses(c => c.AssignableTo<ISingletonLifetime>()).AsImplementedInterfaces().WithSingletonLifetime());
        services.AddTransient<UserManager<User>>();
        services.AddTransient<SignInManager<User>>();
        services.AddTransient<RoleManager<Role>>();
        #endregion

        return services;
    }
}
