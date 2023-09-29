using MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
using MasaTour.TouristTripsManagement.Services.Services.Contracts;

namespace MasaTour.TouristTripsManagement.API.Controllers;

// [Authorize(AuthenticationSchemes = "Bearer", Roles = $"{nameof(Roles.Admin)}")]
[ApiController]
public class TripsController : MasaTourController
{
    private readonly IUnitOfServices _services;
    public TripsController(IMediator mediator, IUnitOfServices services) : base(mediator)
    {
        _services = services;
    }

    #region Post
    [HttpPost(Router.Trip.AddTrip)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTripDto>))]
    public async Task<IActionResult> AddAtrip([FromBody] AddTripDto dto) =>
        MasaTourResponse(await Mediator.Send(new AddTripCommand(dto)));
    #endregion

    #region Put

    [HttpPut(Router.Trip.AddTrip)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTripDto>))]
    public async Task<IActionResult> UpdateTrip([FromBody] UpdateTripDto dto) =>
        MasaTourResponse(await Mediator.Send(new UpdateTripCommand(dto)));
    #endregion

    #region Patch

    [HttpPatch(Router.Trip.DeleteTripById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTripDto>))]
    public async Task<IActionResult> DeleteTripById([Required][MaxLength(36)][MinLength(36)] string id) =>
        MasaTourResponse(await Mediator.Send(new DeleteTripByIdCommand(id)));


    [HttpPatch(Router.Trip.UndoDeleteTripById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTripDto>))]
    public async Task<IActionResult> UndoDeleteTripById([Required][MaxLength(36)][MinLength(36)] string id) =>
        MasaTourResponse(await Mediator.Send(new UndoDeleteTripByIdCommand(id)));
    #endregion

    #region Get
    [HttpGet(Router.Trip.GetTripById)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTripDto>))]
    public async Task<IActionResult> GetTripById([Required][MaxLength(36)][MinLength(36)] string id) =>
        MasaTourResponse(await Mediator.Send(new GetTripByIdQuery(id)));


    [HttpGet(Router.Trip.GetAllTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> GetAllTrips() =>
        MasaTourResponse(await Mediator.Send(new GetAllTripsQuery()));


    [HttpGet(Router.Trip.GetAllActiveTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> GetAllActiveTrips() =>
        MasaTourResponse(await Mediator.Send(new GetAllActiveTripsQuery()));



    [HttpGet(Router.Trip.GetAllNotActiveTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> GetAllNotActiveTrips() =>
        MasaTourResponse(await Mediator.Send(new GetAllNotActiveTripsQuery()));



    [HttpGet(Router.Trip.GetAllDeletedTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> GetAllDeletedTrips() =>
        MasaTourResponse(await Mediator.Send(new GetAllDeletedTripsQuery()));



    [HttpGet(Router.Trip.GetAllUnDeletedTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> GetAllUnDeletedTrips() =>
        MasaTourResponse(await Mediator.Send(new GetAllUnDeletedTripsQuery()));



    [HttpGet(Router.Trip.PaginateUnDeletedTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> PaginateTrips(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TripOrderBy orderBy = TripOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateUnDeletedTripsQuery(pageNumber, pageSize, keyWords, orderBy)));

    [HttpGet(Router.Trip.GetCurrenciesBasedOnUSD)]
    public async Task<IActionResult> GetCurrenciesBasedOnUSD()
    {

        return Ok(await _services.FastForexService.FetchMultiAsync());
    }
    #endregion
}
