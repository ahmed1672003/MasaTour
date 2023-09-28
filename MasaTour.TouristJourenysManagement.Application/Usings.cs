global using System.ComponentModel.DataAnnotations;
global using System.Linq.Expressions;
global using System.Reflection;

global using AutoMapper;

global using MasaTour.TouristTripsManagement.Application.Features.Auth.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Categories.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Enums;
global using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
global using MasaTour.TouristTripsManagement.Application.Resources;
global using MasaTour.TouristTripsManagement.Application.Response;
global using MasaTour.TouristTripsManagement.Domain.Entities;
global using MasaTour.TouristTripsManagement.Domain.Entities.Identity;
global using MasaTour.TouristTripsManagement.Domain.Mandatories.Dtos;
global using MasaTour.TouristTripsManagement.Infrastructure.Constants;
global using MasaTour.TouristTripsManagement.Infrastructure.Enums;
global using MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Categories;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Contracts;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.JWTs;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
global using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Users;
global using MasaTour.TouristTripsManagement.Services.Dtos.Auth;
global using MasaTour.TouristTripsManagement.Services.Dtos.Messages;
global using MasaTour.TouristTripsManagement.Services.Services.Contracts;

global using MediatR;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
namespace MasaTour.TouristTripsManagement.Application;

