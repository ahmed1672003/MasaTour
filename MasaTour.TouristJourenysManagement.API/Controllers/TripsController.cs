using MasaTour.TouristTripsManagement.Application.Features.Trips.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
using MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;

namespace MasaTour.TouristTripsManagement.API.Controllers;

// [Authorize(AuthenticationSchemes = "Bearer", Roles = $"{nameof(Roles.Admin)}")]
[ApiController]
public class TripsController : MasaTourController
{
    public TripsController(IMediator mediator) : base(mediator)
    {
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


    [HttpGet(Router.Trip.GetTripById_Mandatories_Images)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(ResponseModel<GetTrip_Mandatories_Images_Dto>))]
    public async Task<IActionResult> GetTripById_Mandatories_Images([Required][MaxLength(36)][MinLength(36)] string id) =>
        MasaTourResponse(await Mediator.Send(new GetTripById_Mandatories_Images_Query(id)));



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



    [HttpGet(Router.Trip.PaginateDeletedTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> PaginateDeletedTrips(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TripOrderBy orderBy = TripOrderBy.CreatedAt) =>
        MasaTourResponse(await Mediator.Send(new PaginateDeletedTripsQuery(pageNumber, pageSize, keyWords, orderBy)));



    [HttpGet(Router.Trip.PaginateUnDeletedTrips)]
    [Produces(ContentTypes.ApplicationOverJson, Type = typeof(PaginationResponseModel<IEnumerable<GetTripDto>>))]
    public async Task<IActionResult> PaginateUnDeletedTrips(int? pageNumber = 1, int? pageSize = 10, string keyWords = "", TripOrderBy orderBy = TripOrderBy.CreatedAt) =>
     MasaTourResponse(await Mediator.Send(new PaginateUnDeletedTripsQuery(pageNumber, pageSize, keyWords, orderBy)));


    [HttpGet(Router.Trip.GetTripImagesByTripId)]
    public async Task<IActionResult> GetTripImagesByTripId([Required][MaxLength(36)][MinLength(36)] string tipId) => MasaTourResponse(await Mediator.Send(new GetTripImagesByTripIdQuery(tipId)));

    #endregion

    #region Delete
    [HttpDelete(Router.Trip.DeleteImagesFromTrip)]
    public async Task<IActionResult> DeleteImagesFromTrip([Required][MaxLength(36)][MinLength(36)] string tripId, List<string> imagesIds) => MasaTourResponse(await Mediator.Send(new DeleteImagesFromTripCommand(tripId, imagesIds)));
    #endregion
}
