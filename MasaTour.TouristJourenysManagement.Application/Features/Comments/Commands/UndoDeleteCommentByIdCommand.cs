namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Commands;
public sealed record UndoDeleteCommentByIdCommand(string CommentId) : IRequest<ResponseModel<GetCommentDto>>;
