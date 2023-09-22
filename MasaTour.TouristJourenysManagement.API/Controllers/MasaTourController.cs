using MasaTour.TouristJourenysManagement.Application.Response;

using Microsoft.AspNetCore.Mvc;

namespace MasaTour.TouristJourenysManagement.API.Controllers;
//[Route("api/[controller]")]
[ApiController]
public class MasaTourController : ControllerBase
{
    public MasaTourController(IMediator mediator)
    {
        Mediator = mediator;
    }
    public IMediator Mediator { get; }

    #region Results 
    public IActionResult MasaTourResponse<TData>(ResponseModel<TData> response) where TData : class
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);

            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);

            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);

            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);

            case HttpStatusCode.Conflict:
                return new ConflictObjectResult(response);

            case HttpStatusCode.Created:
                return new CreatedResult("data base", response);

            default:
                return new ObjectResult(response)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                };
        }
    }
    #endregion
}
