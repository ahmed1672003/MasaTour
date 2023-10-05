using MasaTour.TouristTripsManagement.Application.Features.Comments.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Commands;
public sealed record UpdateCommentCommand(UpdateCommentDto Dto) : IRequest<ResponseModel<GetCommentDto>>;

