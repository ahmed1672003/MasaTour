using Microsoft.AspNetCore.Http;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class UserCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RefreshTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RevokeTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<DeleteAllUsersCommand, ResponseModel<GetUserDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    #endregion

    #region Ctor
    public UserCommandsHandler(
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        IUnitOfServices services,
        ISpecificationsFactory specificationsFactory,
        IHttpContextAccessor contextAccessor)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _services = services;
        _specificationsFactory = specificationsFactory;
        _contextAccessor = contextAccessor;
    }
    #endregion

    #region Add User 
    public async Task<ResponseModel<AuthModel>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), request.dto.Email);
        try
        {
            if (await _context.Users.AnyAsync(userEmailSpec, cancellationToken))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);

            var user = _mapper.Map<User>(request.dto);
            var identityResult = await _context.Identity.UserManager.CreateAsync(user, request.dto.Password);

            // TODo: Confirm Email

            if (!identityResult.Succeeded)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.Conflict<AuthModel>();

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Created(authModel);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
    #endregion

    #region Refresh Token 
    public async Task<ResponseModel<AuthModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            (string jwt, string refreshToken) = string.IsNullOrEmpty(request.dto.JWT) || string.IsNullOrEmpty(request.dto.RefreshToken) ? await _services.CookiesService.GetAuthInformationsAsync() : (request.dto.JWT, request.dto.RefreshToken);

            ISpecification<UserJWT> jwtIsExistSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(JwtIsExistSpecification), jwt, refreshToken);

            if (!await _context.UserJWTs.AnyAsync(jwtIsExistSpec, cancellationToken))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            var jwtSecurityToken = await _services.AuthService.ReadJWTAsync(jwt);

            if (!await _services.AuthService.IsJWTValid.Invoke(jwt, jwtSecurityToken))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            var getUserJWTByJwtAndRefreshJwtIncludedSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(GetUserJWTByJwtAndRefreshJwtIncludedSpecification), jwt, refreshToken);

            var userJwt = await _context.UserJWTs.RetrieveAsync(getUserJWTByJwtAndRefreshJwtIncludedSpec, cancellationToken);

            if (userJwt.User is null)
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            var authModel = await _services.AuthService.RefreshJWTAsync(userJwt.User);

            if (authModel is null)
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Success(authModel, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
    #endregion

    #region Revoke Token
    public async Task<ResponseModel<AuthModel>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            (string jwt, string refreshToken) = string.IsNullOrEmpty(request.dto.JWT) || string.IsNullOrEmpty(request.dto.RefreshToken) ? await _services.CookiesService.GetAuthInformationsAsync() : (request.dto.JWT, request.dto.RefreshToken);

            ISpecification<UserJWT> jwtIsExistSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(JwtIsExistSpecification), jwt, refreshToken);

            if (!await _context.UserJWTs.AnyAsync(jwtIsExistSpec, cancellationToken))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<UserJWT> getUserJWTByJwtAndRefreshJwtIncludedSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(GetUserJWTByJwtAndRefreshJwtIncludedSpecification), jwt, refreshToken);

            var userJwt = await _context.UserJWTs.RetrieveAsync(getUserJWTByJwtAndRefreshJwtIncludedSpec, cancellationToken);

            if (userJwt.User is null)
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            if (!await _services.AuthService.RevokeJWTAsync(userJwt))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            await _services.CookiesService.DeleteAuthInformationsAsync();

            return ResponseResult.Success<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
    #endregion

    #region Delete All Users 
    public async Task<ResponseModel<GetUserDto>> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!await _context.Users.AnyAsync(cancellationToken: cancellationToken))
                return ResponseResult.NotFound<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

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
