using MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;
using MasaTour.TouristJourenysManagement.Application.Features.Users.Dtos;
using MasaTour.TouristJourenysManagement.Application.Features.Users.Queries;
using MasaTour.TouristJourenysManagement.Infrastructure.Constants;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
[ApiController]
public class UserController : MasaTourController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    [Route(Router.User.AddUser)]
    public async Task<IActionResult> AddUser([FromForm] AddUserDto dto) => MasaTourResponse(await Mediator.Send(new AddUserCommand(dto)));

    [HttpGet]
    [Route(Router.User.GetAllUsers)]
    //public async Task<IActionResult> GetAllUsers() => MasaTourResponse(await Mediator.Send(new GetAllUsersQuery()));
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await Mediator.Send(new GetAllUsersQuery());
        return MasaTourResponse(response);
    }
}
