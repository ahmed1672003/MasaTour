namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries.Handlers;
public sealed class UserQueriesHandler :
    IRequestHandler<GetUserByIdQuery, ResponseModel<GetUserDto>>,
    IRequestHandler<GetAllUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>
{
    #region Field
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion

    #region Ctor
    public UserQueriesHandler(
        IUnitOfWork context,
        IUnitOfServices services,
        IMapper mapper,
        IStringLocalizer<SharedResources> stringLocalizer,
        ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _services = services;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
        _specificationsFactory = specificationsFactory;
    }
    #endregion

    #region Get User By Id
    public async Task<ResponseModel<GetUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // check if user found
            ISpecification<User> userByIdSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingGetUserByIdSpecification), request.Id);
            if (!await _context.Users.AnyAsync(userByIdSpec))
                return ResponseResult.NotFound<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            GetUserDto dto = _mapper.Map<GetUserDto>(await _context.Users.RetrieveAsync(userByIdSpec));
            return ResponseResult.Success(dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Get All Users Query
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
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
