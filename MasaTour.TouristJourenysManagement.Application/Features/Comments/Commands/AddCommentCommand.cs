using MasaTour.TouristTripsManagement.Application.Features.Comments.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Commands;
public sealed record AddCommentCommand(AddCommentDto Dto) : IRequest<ResponseModel<GetCommentDto>>;
