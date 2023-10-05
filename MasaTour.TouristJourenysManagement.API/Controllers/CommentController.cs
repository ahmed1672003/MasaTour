using MasaTour.TouristTripsManagement.Application.Features.Comments.Commands;
using MasaTour.TouristTripsManagement.Application.Features.Comments.Dtos;

namespace MasaTour.TouristTripsManagement.API.Controllers;

[ApiController]
public class CommentController : MasaTourController
{
    public CommentController(IMediator mediator) : base(mediator)
    {
    }

    #region Post
    [HttpPost(Router.Comment.AddComment)]
    public async Task<IActionResult> AddComment(AddCommentDto dto) => MasaTourResponse(await Mediator.Send(new AddCommentCommand(dto)));
    #endregion

    #region Put
    [HttpPut(Router.Comment.UpdateComment)]
    public async Task<IActionResult> UpdateComment(UpdateCommentDto dto) => MasaTourResponse(await Mediator.Send(new UpdateCommentCommand(dto)));
    #endregion

    #region Patch
    [HttpPatch(Router.Comment.DeleteCommentById)]
    public async Task<IActionResult> DeleteCommentById([Required][MaxLength(36)][MinLength(36)] string commentId) => MasaTourResponse(await Mediator.Send(new DeleteCommentByIdCommand(commentId)));

    [HttpPatch(Router.Comment.UndoDeleteCommentById)]
    public async Task<IActionResult> UndoDeleteCommentById([Required][MaxLength(36)][MinLength(36)] string commentId) => MasaTourResponse(await Mediator.Send(new UndoDeleteCommentByIdCommand(commentId)));
    #endregion


    #region Get


    #endregion

}
