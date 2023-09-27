using MasaTour.TouristTripsManagement.Application.Features.Enums;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;

namespace MasaTour.TouristTripsManagement.API.Controllers;

// [Authorize(AuthenticationSchemes = "Bearer", Roles = $"{nameof(Roles.Admin)}")]
[ApiController]
public class TripController : MasaTourController
{
    public TripController(IMediator mediator) : base(mediator) { }

    #region Post
    [HttpPost(Router.Trip.AddTrip)]
    public async Task<IActionResult> AddAtrip([FromBody] AddTripDto dto) => MasaTourResponse(await Mediator.Send(new AddTripCommand(dto)));

    #endregion

    #region Put
    [HttpPut(Router.Trip.AddTrip)]
    public async Task<IActionResult> UpdateTrip([FromBody] UpdateTripDto dto) => MasaTourResponse(await Mediator.Send(new UpdateTripCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Trip.DeleteTripById)]
    public async Task<IActionResult> DeleteTripById([Required][MaxLength(36)][MinLength(36)] string id) => MasaTourResponse(await Mediator.Send(new DeleteTripByIdCommand(id)));

    [HttpPatch(Router.Trip.UndoDeleteTripById)]
    public async Task<IActionResult> UndoDeleteTripById([Required][MaxLength(36)][MinLength(36)] string id) => MasaTourResponse(await Mediator.Send(new UndoDeleteTripByIdCommand(id)));
    #endregion

    #region Get
    [HttpGet(Router.Trip.GetTripById)]
    public async Task<IActionResult> GetTripById([Required][MaxLength(36)][MinLength(36)] string id) => MasaTourResponse(await Mediator.Send(new GetTripByIdQuery(id)));

    [HttpGet(Router.Trip.GetAllTrips)]
    public async Task<IActionResult> GetAllTrips() => MasaTourResponse(await Mediator.Send(new GetAllTripsQuery()));

    [HttpGet(Router.Trip.GetAllActiveTrips)]
    public async Task<IActionResult> GetAllActiveTrips() => MasaTourResponse(await Mediator.Send(new GetAllActiveTripsQuery()));

    [HttpGet(Router.Trip.GetAllNotActiveTrips)]
    public async Task<IActionResult> GetAllNotActiveTrips() => MasaTourResponse(await Mediator.Send(new GetAllNotActiveTripsQuery()));

    [HttpGet(Router.Trip.GetAllDeletedTrips)]
    public async Task<IActionResult> GetAllDeletedTrips() => MasaTourResponse(await Mediator.Send(new GetAllDeletedTripsQuery()));

    [HttpGet(Router.Trip.GetAllUnDeletedTrips)]
    public async Task<IActionResult> GetAllUnDeletedTrips() => MasaTourResponse(await Mediator.Send(new GetAllUnDeletedTripsQuery()));

    [HttpGet(Router.Trip.PaginateTrips)]
    public async Task<IActionResult> PaginateTrips(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TripOrderBy orderBy = TripOrderBy.CreatedAt) => MasaTourResponse(await Mediator.Send(new PaginateTripsQuery(pageNumber, pageSize, keyWords, orderBy)));
    #endregion
}
