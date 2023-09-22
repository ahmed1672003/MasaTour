using System.ComponentModel.DataAnnotations;

using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Queries.Handlers;
public sealed class UsersQueriesHandler :
    IRequestHandler<LoginUserQuery, ResponseModel<AuthModel>>,
    IRequestHandler<GetAllUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>
{
    #region Fields

    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly IMapper _mapper;
    private ISpecificationsFactory _specificationsFactory;
    #endregion

    #region Ctor
    public UsersQueriesHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, ISpecificationsFactory specificationsFactory, IUnitOfServices services)
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
        var isEmailValid = new EmailAddressAttribute().IsValid(request.dto.EmailOrUserName);
        // check user name or email found
        ISpecification<User> userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), request.dto.EmailOrUserName);
        ISpecification<User> userNameSpec = _specificationsFactory.CreateUserSpecifications(typeof(UserNameIsExistSpecification), request.dto.EmailOrUserName);
        if (!await _context.Users.AnyAsync(isEmailValid ? userEmailSpec : userNameSpec, cancellationToken))
            return ResponseResult.NotFound<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
        try
        {
            var user = await _context.Users.RetrieveAsync(_specificationsFactory.CreateUserSpecifications(typeof(GetUserByUserNameOrEmailIncludedJwtSpecification), request.dto.EmailOrUserName), cancellationToken);

            // ToDo: check if email confirm

            var signInResult = await _context.Identity.SignInManager.CheckPasswordSignInAsync(user, request.dto.Password, true);

            if (!signInResult.Succeeded)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            var authModel = await _services.AuthService.GetJWTAsync(user);

            if (authModel is null)
                return ResponseResult.UnAuthorized<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.UnAuthorized]);

            return ResponseResult.Success(authModel, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
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
        catch
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
    #endregion
}
