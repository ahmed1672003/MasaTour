global using System.Linq.Expressions;
global using System.Reflection;

global using MasaTour.TouristJourenysManagement.Domain.Constants;
global using MasaTour.TouristJourenysManagement.Domain.Entities;
global using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Context;
global using MasaTour.TouristJourenysManagement.Infrastructure.Context.Interceptors;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Seeds;
global using MasaTour.TouristJourenysManagement.Infrastructure.Settings;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Categories;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Roles;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;


namespace MasaTour.TouristJourenysManagement.Infrastructure;
