namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Commands;
public sealed record DeleteCommentByIdCommand(string CommentId) : IRequest<ResponseModel<GetCommentDto>>;
