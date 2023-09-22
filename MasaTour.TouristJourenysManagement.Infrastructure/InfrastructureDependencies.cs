using MasaTour.TouristJourenysManagement.Infrastructure.Seeds;
using MasaTour.TouristJourenysManagement.Infrastructure.Settings;

namespace MasaTour.TouristJourenysManagement.Infrastructure;
public static class InfrastructureDependencies
{
    public static async Task<IServiceCollection> AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register DbContext Options
        services.AddDbContext<ITouristJourenysManagementDbContext, TouristJourenysManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MasaTour_TouristJourenysManagement"));
        }, ServiceLifetime.Scoped);
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

        #region Register Contracts
        services
                .AddScoped<UserManager<User>>()
                .AddScoped<SignInManager<User>>()
                .AddScoped<RoleManager<Role>>()
                .AddScoped<ISpecificationsFactory, SpecificationsFactory>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IIdentityRepository, IdentityRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IRoleClaimRepository, RoleClaimRepository>()
                .AddScoped<IUserClaimRepository, UserClaimRepository>()
                .AddScoped<IUserJWTRepository, UserJWTRepository>()
                .AddScoped<IUserLoginRepository, UserLoginRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRoleMapperRepository, UserRoleMapperRepository>()
                .AddScoped<IUserTokenRepository, UserTokenRepository>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped(typeof(ISpecification<>), typeof(Specification<>));
        #endregion

        #region Seed Data
        var context = services.BuildServiceProvider().GetRequiredService<IUnitOfWork>();
        var specificationsFactory = services.BuildServiceProvider().GetRequiredService<ISpecificationsFactory>();
        try
        {
            await RolesSedeer.SeedRolesAsync(context);
            await UsersSedeer.SeedSuperAdminAsync(context, specificationsFactory);
            await UsersSedeer.SeedAdminAsync(context, specificationsFactory);
            await UsersSedeer.SeedBasicAsync(context, specificationsFactory);
        }
        catch
        {

        }
        #endregion

        #region Configurations
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        #endregion

        return services;
    }
}
