global using System.ComponentModel.DataAnnotations;
global using System.Net;

global using MasaTour.TouristJourenysManagement.API;
global using MasaTour.TouristJourenysManagement.Application;
global using MasaTour.TouristJourenysManagement.Application.Features.Auth.Commands;
global using MasaTour.TouristJourenysManagement.Application.Features.Auth.Dtos;
global using MasaTour.TouristJourenysManagement.Application.Features.Auth.Queries;
global using MasaTour.TouristJourenysManagement.Application.Features.Categories.Commands;
global using MasaTour.TouristJourenysManagement.Application.Features.Categories.Dtos;
global using MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
global using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
global using MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
global using MasaTour.TouristJourenysManagement.Application.Response;
global using MasaTour.TouristJourenysManagement.Domain;
global using MasaTour.TouristJourenysManagement.Infrastructure;
global using MasaTour.TouristJourenysManagement.Infrastructure.Constants;
global using MasaTour.TouristJourenysManagement.Infrastructure.Enums;
global using MasaTour.TouristJourenysManagement.Services;

global using MediatR;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;

global using Swashbuckle.AspNetCore.Annotations;
namespace MasaTour.TouristJourenysManagement.API;

