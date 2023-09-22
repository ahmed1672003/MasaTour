using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResponseModel<AuthModel>>
{
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly ISpecificationsFactory _specificationsFactory;
    public AddUserCommandHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, IUnitOfServices services, ISpecificationsFactory specificationsFactory)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _services = services;
        _specificationsFactory = specificationsFactory;
    }
    public async Task<ResponseModel<AuthModel>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        //EmailIsExistSpecification userEmailSpec = new(request.dto.Email);

        var userEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(EmailIsExistSpecification), request.dto.Email);

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

            return ResponseResult.Success(authModel);
        }
        catch
        {
            return ResponseResult.InternalServerError<AuthModel>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
}
