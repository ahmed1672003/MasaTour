﻿namespace MasaTour.TouristTripsManagement.Services;
public static class ServicesDependencies
{
    public static IServiceCollection AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register Services
        services.AddHttpClient();
        services.AddScoped<IUnitOfServices, UnitOfSevices>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ICookiesService, CookiesService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IFastForexService, FastForexService>()
                .AddScoped<IFileService, FileService>();
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        services.Configure<FastForexSettings>(configuration.GetSection(nameof(FastForexSettings)));
        #endregion

        #region JWT Services
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {

            options.RequireHttpsMetadata = false;
            options.SaveToken = false;
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration.GetValue<string>($"{nameof(JwtSettings)}:{nameof(JwtSettings.Issuer)}"),
                ValidAudience = configuration.GetValue<string>($"{nameof(JwtSettings)}:{nameof(JwtSettings.Audience)}"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>($"{nameof(JwtSettings)}:{nameof(JwtSettings.Secret)}"))),
            };
        });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = "MasaTourApi", Version = "1.0.0", Contact = new OpenApiContact() { Email = "ahmedadel1672003@gmail.com", Name = "ahmed adel" } });
            options.EnableAnnotations();
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new()
            {
                Description = "JWT Authorization",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = JwtBearerDefaults.AuthenticationScheme,
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                        {
                            Reference = new()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme,
                            }
                        },
                    Array.Empty<string>()
                }
            });
        });
        #endregion

        return services;
    }
}
