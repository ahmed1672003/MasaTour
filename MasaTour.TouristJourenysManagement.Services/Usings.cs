global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;

global using MasaTour.TouristTripsManagement.Domain.Entities.Identity;
global using MasaTour.TouristTripsManagement.Domain.Exceptions.Image;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristTripsManagement.Infrastructure.Settings;
global using MasaTour.TouristTripsManagement.Services.Services;
global using MasaTour.TouristTripsManagement.Services.Services.Contracts;
global using MasaTour.TouristTripsManagement.Services.Settings;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
namespace MasaTour.TouristTripsManagement.Services;

