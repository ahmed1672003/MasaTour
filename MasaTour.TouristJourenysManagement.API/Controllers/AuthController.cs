using Microsoft.AspNetCore.Mvc;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
[ApiController]
public class AuthController : MasaTourController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost]
    [Route(Router.Auth.AddUser)]
    public async Task<IActionResult> AddUser([FromForm] AddUserDto dto) => MasaTourResponse(await Mediator.Send(new AddUserCommand(dto)));
    #endregion

    #region Put
    [HttpPut]
    [Route(Router.Auth.LoginUser)]
    public async Task<IActionResult> LoginUser([FromForm] LoginUserDto dto) => MasaTourResponse(await Mediator.Send(new LoginUserQuery(dto)));

    [HttpPut]
    [Route(Router.Auth.RefreshToken)]
    public async Task<IActionResult> RefreshUserToken([FromForm] RefreshTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RefreshTokenCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch]
    [Route(Router.Auth.RevokeToken)]
    public async Task<IActionResult> RevokeUserToken([FromForm] RevokeTokenRequestDto dto) => MasaTourResponse(await Mediator.Send(new RevokeTokenCommand(dto)));
    #endregion

    #region Get
    [HttpGet]
    [Route(Router.Auth.GetAllUsers)]
    public async Task<IActionResult> GetAllUsers() => MasaTourResponse(await Mediator.Send(new GetAllUsersQuery()));
    #endregion

    #region Delete
    [HttpDelete]
    [Route(Router.Auth.DeleteAllUsers)]
    public async Task<IActionResult> DeleteAllUsers() => MasaTourResponse(await Mediator.Send(new DeleteAllUsersCommand()));
    #endregion
}
