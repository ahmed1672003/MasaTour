using System.Globalization;
using System.Text.Json.Serialization;

using MasaTour.TouristJourenysManagement.Application.Middlewares;

using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace MasaTour.TouristJourenysManagement.API;

public static class Startup
{
    public static void Build(WebApplication app)
    {
        app.UseSwagger()
           .UseSwaggerUI()
           .UseCors("MasaTour")
           .UseMiddleware<ErrorHandlerMiddleWare>()
           .UseHttpsRedirection()
           .UseAuthorization()
           .UseAuthentication()
           .UseRequestLocalization(new RequestLocalizationOptions
           {
               ApplyCurrentCultureToResponseHeaders = true,
           });
        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        app.UseStaticFiles();
        app.MapControllers();

        app.Run();
    }

    public static async Task<IServiceCollection> AddAPIDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDependencies()
                .AddServicesDependencies(configuration)
                .AddDomainDependencies();

        await services.AddInfrastructureDependencies(configuration);

        services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        #region Allow All Cors Origin
        services
            .AddCors(options =>
            {
                options.AddPolicy("MasaTour", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
        #endregion

        #region Add Localization

        services
            .AddLocalization(/*options => options.ResourcesPath = ""*/)
            .Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"), // english
                    new CultureInfo("ar-EG"), // arabic
                    new CultureInfo("de-DE"), // germaney
                    new CultureInfo("fr-FR"), // frensh
                    new CultureInfo("es"), // spanish
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        #endregion

        #region Add Authorization Policy

        #endregion

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
