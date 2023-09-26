global using System.Linq.Expressions;
global using System.Reflection;

global using MasaTour.TouristTripsManagement.Domain.Constants;
global using MasaTour.TouristTripsManagement.Domain.Entities;
global using MasaTour.TouristTripsManagement.Domain.Entities.Identity;
global using MasaTour.TouristTripsManagement.Infrastructure.Context;
global using MasaTour.TouristTripsManagement.Infrastructure.Context.Interceptors;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts.Identity;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories.Identity;
global using MasaTour.TouristTripsManagement.Infrastructure.Seeds;
global using MasaTour.TouristTripsManagement.Infrastructure.Settings;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Contracts;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.JWTs;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Roles;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;


namespace MasaTour.TouristTripsManagement.Infrastructure;
