global using System.ComponentModel.DataAnnotations;
global using System.Globalization;
global using System.Net;
global using System.Text.Json.Serialization;

global using MasaTour.TouristTripsManagement.API;
global using MasaTour.TouristTripsManagement.Application;
global using MasaTour.TouristTripsManagement.Application.Features.Auth.Commands;
global using MasaTour.TouristTripsManagement.Application.Features.Auth.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Auth.Queries;
global using MasaTour.TouristTripsManagement.Application.Features.Categories.Commands;
global using MasaTour.TouristTripsManagement.Application.Features.Categories.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Enums;
global using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Commands;
global using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.SubCategories.Queries;
global using MasaTour.TouristTripsManagement.Application.Features.Users.Commands;
global using MasaTour.TouristTripsManagement.Application.Features.Users.Dtos;
global using MasaTour.TouristTripsManagement.Application.Features.Users.Queries;
global using MasaTour.TouristTripsManagement.Application.Middlewares;
global using MasaTour.TouristTripsManagement.Application.Response;
global using MasaTour.TouristTripsManagement.Domain;
global using MasaTour.TouristTripsManagement.Infrastructure;
global using MasaTour.TouristTripsManagement.Infrastructure.Constants;
global using MasaTour.TouristTripsManagement.Infrastructure.Enums;
global using MasaTour.TouristTripsManagement.Services;

global using MediatR;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Localization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;

global using Swashbuckle.AspNetCore.Annotations;
namespace MasaTour.TouristTripsManagement.API;

