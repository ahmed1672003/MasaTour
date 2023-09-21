global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;

global using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Settings;
global using MasaTour.TouristJourenysManagement.Services.Dtos;
global using MasaTour.TouristJourenysManagement.Services.Services.Contracts;

global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
namespace MasaTour.TouristJourenysManagement.Services;

