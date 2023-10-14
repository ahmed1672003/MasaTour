namespace MasaTour.TouristTripsManagement.Application.Features.Auth.Commands.Handlers;
public sealed class AuthCommandsHandler :
    IRequestHandler<AddUserCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RefreshTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<RevokeTokenCommand, ResponseModel<AuthModel>>,
    IRequestHandler<ChangePasswordCommand, ResponseModel<AuthModel>>,
    IRequestHandler<ConfirmeEmailCommand, ResponseModel<AuthModel>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IFileService _fileService;
    #endregion

    #region Ctor
    public AuthCommandsHandler(
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        IUnitOfServices services,
        ISpecificationsFactory specificationsFactory,
        IHttpContextAccessor contextAccessor,
        IFileService fileService)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _services = services;
        _specificationsFactory = specificationsFactory;
        _contextAccessor = contextAccessor;
        _fileService = fileService;
    }
    #endregion

    #region Add User 
    public async Task<ResponseModel<AuthModel>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // check is email exist
            ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), request.dto.Email);
            if (await _context.Users.AnyAsync(userEmailSpec, cancellationToken))
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);

            // add user
            var user = _mapper.Map<User>(request.dto);

            // add image
            if (request.dto.Img is not null)
            {
                _fileService.EnsureFileExctension(request.dto.Img);
                _fileService.EnsureFileSize(request.dto.Img);

                UploadFileResultDto uploadFile = await _fileService.UploadFileAsync(request.dto.Img, "UsersImages");

                if (!uploadFile.Success)
                    return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);

                user.FileName = uploadFile.FileName;
                user.FilePath = uploadFile.FilePath;
            }


            var createUserResult = await _context.Identity.UserManager.CreateAsync(user, request.dto.Password);

            if (!createUserResult.Succeeded)
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // generate confirme email token
            string token = await _context.Identity.UserManager.GenerateEmailConfirmationTokenAsync(user);
            HttpRequest httpRequest = _contextAccessor.HttpContext.Request;

            // redirect url
            string redirectUrl = $"{httpRequest.Scheme.Trim()}://{httpRequest.Host.ToUriComponent().Trim().ToLower()}/{Router.Auth.ConfirmeEmail}";

            // set confirme email parameters
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                {"Token",token},
                { "UserId" , user.Id}
            };

            // create uri
            Uri url = new Uri(QueryHelpers.AddQueryString(redirectUrl, parameters));

            // send email
            SendEmailDto sendEmailDto = await _services.EmailService.SendEmailAsync(user.Email, "Confirm Your Email", url.ToString());

            if (!sendEmailDto.IsSendSuccess)
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // add user to role
            var assignUserToRoleResult = await _context.Identity.UserManager.AddToRoleAsync(user, Roles.Basic.ToString());

            if (!assignUserToRoleResult.Succeeded)
                return ResponseResult.BadRequest<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // generate jwt
            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.BadRequest<AuthModel>();

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Created(authModel, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
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
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
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
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
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
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Confirme Email
    public async Task<ResponseModel<AuthModel>> Handle(ConfirmeEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // read token and userId From Query By HttpContext Because Automatic DotNet Query Reader Sometimes Read Token  Incorrectly
            string token = _contextAccessor.HttpContext.Request.Query["Token"];
            string UserId = _contextAccessor.HttpContext.Request.Query["UserId"];

            // confirme email
            bool isEmailConfirmed = await _context.Identity.ConfirmEmailAsync(token, UserId, cancellationToken);

            if (!isEmailConfirmed)
                return ResponseResult.Conflict<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Conflict]);

            return ResponseResult.Success<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
