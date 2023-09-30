namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Queries;
public sealed record GetTripById_Mandatories_Images_Query([Required] string TripId) : IRequest<ResponseModel<GetTrip_Mandatories_Images_Dto>>;
