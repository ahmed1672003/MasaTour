using MasaTour.TouristTripsManagement.Application.Features.TripPhases.Commands;

namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class TripPhasesController : MasaTourController
{
    public TripPhasesController(IMediator mediator) : base(mediator) { }

    #region Update
    [HttpPut(Router.TripPhase.UpdateTripPhase)]
    public async Task<IActionResult> UpdateTripPhase(UpdateTripPhaseDto dto) => MasaTourResponse(await Mediator.Send(new UpdateTripPhaseCommand(dto)));
    #endregion

    #region Get
    [HttpGet(Router.TripPhase.GetAllTripPhasesByTripId)]
    public async Task<IActionResult> GetAllTripPhasesByTripId([Required][MaxLength(36)][MinLength(36)] string tripId) => MasaTourResponse(await Mediator.Send(new GetAllTripPhasesByTripIdQuery(tripId)));
    #endregion

    #region Delete
    [HttpDelete(Router.TripPhase.DeleteTripPhaseByPhaseId)]
    public async Task<IActionResult> DeleteTripPhaseByPhaseId([Required][MaxLength(36)][MinLength(36)] string phaseId) => MasaTourResponse(await Mediator.Send(new DeleteTripPhaseByPhaseIdCommand(phaseId)));

    [HttpDelete(Router.TripPhase.DeleteAllTripPhasesByTripId)]
    public async Task<IActionResult> DeleteAllTripPhasesByTripId([Required][MaxLength(36)][MinLength(36)] string tripId) => MasaTourResponse(await Mediator.Send(new DeleteTripPhasesByTripIdCommand(tripId)));
    #endregion
}
