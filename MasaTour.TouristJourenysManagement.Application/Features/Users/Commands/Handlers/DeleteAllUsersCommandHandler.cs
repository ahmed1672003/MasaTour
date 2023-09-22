namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class DeleteAllUsersCommandHandler : IRequestHandler<DeleteAllUsersCommand, ResponseModel<GetUserDto>>
{
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public DeleteAllUsersCommandHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<ResponseModel<GetUserDto>> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Users.AnyAsync(cancellationToken: cancellationToken))
            return ResponseResult.NotFound<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
        try
        {
            await _context.Users.ExecuteDeleteAsync(cancellationToken: cancellationToken);
            return ResponseResult.Success<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch
        {
            return ResponseResult.InternalServerError<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
}
