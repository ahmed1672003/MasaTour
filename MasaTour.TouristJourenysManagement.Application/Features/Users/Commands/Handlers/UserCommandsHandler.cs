using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class UserCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthModel>>,
    IRequestHandler<DeleteAllUsersCommand, ResponseModel<GetUserDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    #endregion

    #region Ctor
    public UserCommandsHandler(
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        IUnitOfServices services,
        ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _services = services;
        _specificationsFactory = specificationsFactory;
    }
    #endregion

    #region Add User Command
    public async Task<ResponseModel<AuthModel>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), request.dto.Email);

        if (await _context.Users.AnyAsync(userEmailSpec, cancellationToken))
            return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);
        try
        {
            var user = _mapper.Map<User>(request.dto);
            var identityResult = await _context.Identity.UserManager.CreateAsync(user, request.dto.Password);

            // TODo: Confirm Email

            if (!identityResult.Succeeded)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.Conflict<AuthModel>();

            return ResponseResult.Created(authModel);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
    #endregion

    #region Delete All Users Command
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

    #endregion
}
