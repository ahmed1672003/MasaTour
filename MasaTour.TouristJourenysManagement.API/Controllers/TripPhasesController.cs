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
    [HttpGet(Router.TripPhase.GetAllTripPhasesGroupingByTripId)]
    public async Task<IActionResult> GetAllTripPhasesGroupingByTripId() => MasaTourResponse(await Mediator.Send(new GetAllTripPhasesGroupingByTripIdQuery()));
    #endregion

    #region Delete

    #endregion
}
