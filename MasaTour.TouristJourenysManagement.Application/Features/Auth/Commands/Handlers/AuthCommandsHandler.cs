using MasaTour.TouristJourenysManagement.Infrastructure.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Commands.Handlers;
public sealed class AuthCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RefreshTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RevokeTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<ChangePasswordCommand, ResponseModel<AuthModel>>
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
    public AuthCommandsHandler(
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
        try
        {
            ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), request.dto.Email);
            if (await _context.Users.AnyAsync(userEmailSpec, cancellationToken))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);

            var user = _mapper.Map<User>(request.dto);
            var createUserResult = await _context.Identity.UserManager.CreateAsync(user, request.dto.Password);

            // TODo: Confirm Email

            if (!createUserResult.Succeeded)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            var assignUserToRoleResult = await _context.Identity.UserManager.AddToRoleAsync(user, Roles.Basic.ToString());

            if (!assignUserToRoleResult.Succeeded)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.Conflict<AuthModel>();

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Created(authModel);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.InnerException?.Message });
        }
    }
    #endregion

    #region Refresh Token 
    public async Task<ResponseModel<AuthModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            (string jwt, string refreshToken) = string.IsNullOrEmpty(request.dto.JWT) || string.IsNullOrEmpty(request.dto.RefreshToken) ? await _services.CookiesService.GetAuthInformationsAsync() : (request.dto.JWT, request.dto.RefreshToken);

            ISpecification<UserJWT> jwtIsExistSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(AsNoTrackingJwtIsExistSpecification), jwt, refreshToken);

            if (!await _context.UserJWTs.AnyAsync(jwtIsExistSpec, cancellationToken))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            var jwtSecurityToken = await _services.AuthService.ReadJWTAsync(jwt);

            if (!await _services.AuthService.IsJWTValid.Invoke(jwt, jwtSecurityToken))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            var getUserJWTByJwtAndRefreshJwtIncludedSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification), jwt, refreshToken);

            var userJwt = await _context.UserJWTs.RetrieveAsync(getUserJWTByJwtAndRefreshJwtIncludedSpec, cancellationToken);

            if (userJwt.User is null)
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            var authModel = await _services.AuthService.RefreshJWTAsync(userJwt.User);

            if (authModel is null)
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Success(authModel, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.InnerException?.Message });
        }
    }
    #endregion

    #region Revoke Token
    public async Task<ResponseModel<AuthModel>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            (string jwt, string refreshToken) = string.IsNullOrEmpty(request.dto.JWT) || string.IsNullOrEmpty(request.dto.RefreshToken) ? await _services.CookiesService.GetAuthInformationsAsync() : (request.dto.JWT, request.dto.RefreshToken);

            ISpecification<UserJWT> jwtIsExistSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(AsNoTrackingJwtIsExistSpecification), jwt, refreshToken);

            if (!await _context.UserJWTs.AnyAsync(jwtIsExistSpec, cancellationToken))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<UserJWT> getUserJWTByJwtAndRefreshJwtIncludedSpec = _specificationsFactory.CreateUserJWTSpecifications(typeof(AsTrackingGetUserJWTByJwtAndRefreshJwtIncludedSpecification), jwt, refreshToken);

            var userJwt = await _context.UserJWTs.RetrieveAsync(getUserJWTByJwtAndRefreshJwtIncludedSpec, cancellationToken);

            if (userJwt.User is null)
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            if (!await _services.AuthService.RevokeJWTAsync(userJwt))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            await _services.CookiesService.DeleteAuthInformationsAsync();

            return ResponseResult.Success<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.InnerException?.Message });
        }
    }
    #endregion

    #region Change Password
    public async Task<ResponseModel<AuthModel>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> getUserByUserNameOrEmailSpecification = _specificationsFactory.CreateUserSpecifications(typeof(AsTrackingGetUserByUserNameOrEmailSpecification), request.dto.EmailOrUserName);
            if (!await _context.Users.AnyAsync(getUserByUserNameOrEmailSpecification))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            User user = await _context.Users.RetrieveAsync(getUserByUserNameOrEmailSpecification);

            bool IsSecure = await _context.Identity.UserManager.CheckPasswordAsync(user, request.dto.CurrentPassword);

            if (!IsSecure)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            IdentityResult changePassword = await _context.Identity.UserManager.ChangePasswordAsync(user, request.dto.CurrentPassword, request.dto.Password);

            if (!changePassword.Succeeded)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            return ResponseResult.Success<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.InnerException?.Message });
        }
    }
    #endregion


}
