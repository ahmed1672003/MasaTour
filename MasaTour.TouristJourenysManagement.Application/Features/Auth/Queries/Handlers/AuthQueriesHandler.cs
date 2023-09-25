namespace MasaTour.TouristJourenysManagement.Application.Features.Auth.Queries.Handlers;
public sealed class AuthQueriesHandler :
    IRequestHandler<LoginUserQuery, ResponseModel<AuthModel>>
{
    #region Fields

    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public AuthQueriesHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, ISpecificationsFactory specificationsFactory, IUnitOfServices services)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
        _services = services;
    }
    #endregion

    #region Login User Query
    public async Task<ResponseModel<AuthModel>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var isEmailValid = new EmailAddressAttribute().IsValid(request.dto.EmailOrUserName);
            // check user name or email found
            ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingEmailIsExistSpecification), request.dto.EmailOrUserName);
            ISpecification<User> userNameSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingUserNameIsExistSpecification), request.dto.EmailOrUserName);
            if (!await _context.Users.AnyAsync(isEmailValid ? userEmailSpec : userNameSpec, cancellationToken))
                return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            var user = await _context.Users.RetrieveAsync(_specificationsFactory.CreateUserSpecifications(typeof(AsTrackingGetUserByUserNameOrEmailIncludedJwtSpecification), request.dto.EmailOrUserName), cancellationToken);

            // check if email confirm
            if (!user.EmailConfirmed)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            var signInResult = await _context.Identity.SignInManager.CheckPasswordSignInAsync(user, request.dto.Password, true);

            if (!signInResult.Succeeded)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            await _services.CookiesService.SaveAuthInformationsAsync(authModel);

            return ResponseResult.Success(authModel, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
