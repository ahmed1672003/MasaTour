using Microsoft.AspNetCore.Mvc;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
[ApiController]
public class UserController : MasaTourController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    [Route(Router.User.AddUser)]
    public async Task<IActionResult> AddUser([FromForm] AddUserDto dto) => MasaTourResponse(await Mediator.Send(new AddUserCommand(dto)));


    [HttpPatch]
    [Route(Router.User.LoginUser)]
    public async Task<IActionResult> LoginUser([FromForm] LoginUserDto dto) => MasaTourResponse(await Mediator.Send(new LoginUserQuery(dto)));


    [HttpGet]
    [Route(Router.User.GetAllUsers)]
    public async Task<IActionResult> GetAllUsers() => MasaTourResponse(await Mediator.Send(new GetAllUsersQuery()));

    [HttpDelete]
    [Route(Router.User.DeleteAllUsers)]
    public async Task<IActionResult> DeleteAllUsers() => MasaTourResponse(await Mediator.Send(new DeleteAllUsersCommand()));
}
