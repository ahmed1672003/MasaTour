global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;

global using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Settings;
global using MasaTour.TouristJourenysManagement.Services.Services;
global using MasaTour.TouristJourenysManagement.Services.Services.Contracts;
global using MasaTour.TouristJourenysManagement.Services.Settings;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
namespace MasaTour.TouristJourenysManagement.Services;

