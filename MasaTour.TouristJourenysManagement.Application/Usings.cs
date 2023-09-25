global using System.Reflection;

global using AutoMapper;

global using FluentValidation;

global using MasaTour.TouristJourenysManagement.Application.Behaviors;
global using MasaTour.TouristJourenysManagement.Application.Features.Auth.Dtos;
global using MasaTour.TouristJourenysManagement.Application.Resources;
global using MasaTour.TouristJourenysManagement.Application.Response;
global using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
global using MasaTour.TouristJourenysManagement.Infrastructure.Constants;
global using MasaTour.TouristJourenysManagement.Infrastructure.Enums;
global using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.JWTs;
global using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;
global using MasaTour.TouristJourenysManagement.Services.Dtos.Auth;
global using MasaTour.TouristJourenysManagement.Services.Dtos.Messages;
global using MasaTour.TouristJourenysManagement.Services.Services.Contracts;

global using MediatR;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
namespace MasaTour.TouristJourenysManagement.Application;

