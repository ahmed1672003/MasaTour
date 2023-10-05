namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Queries;
public sealed record GetAllCommentByTripIdQuery(string TripId) : IRequest<ResponseModel<IEnumerable<GetCommentDto>>>;
