using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
[Authorize]
[ApiController]
public class UserController : MasaTourController
{
    public UserController(IMediator mediator) : base(mediator) { }
}
