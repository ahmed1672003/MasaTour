namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries.Handlers;
public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>
{
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }
    public async Task<ResponseModel<IEnumerable<GetUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        if (!await _context.Users.AnyAsync(cancellationToken: cancellationToken))
            return ResponseResult.NotFound<IEnumerable<GetUserDto>>();
        try
        {
            var users = await _context.Users.RetrieveAllAsync(cancellationToken: cancellationToken);
            var dtos = _mapper.Map<IEnumerable<GetUserDto>>(users);
            return ResponseResult.Success(dtos);
        }
        catch
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
}
