namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class UserComandsHandler
    : IRequestHandler<UpdateUserCommand, ResponseModel<GetUserDto>>
{
    private readonly IUnitOfServices _services;
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;

    public UserComandsHandler(
        IUnitOfServices services,
        IUnitOfWork context,
        IStringLocalizer<SharedResources> stringLocalizer,
        IMapper mapper,
        ISpecificationsFactory specificationsFactory)
    {
        _services = services;
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
        _specificationsFactory = specificationsFactory;
    }

    #region Update User
    public async Task<ResponseModel<GetUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // check user 
            ISpecification<User> userIdSpec = _specificationsFactory.CreateUserSpecifications(typeof(UserIdIsExistSpecification), request.dto.Id);
            if (!await _context.Users.AnyAsync(userIdSpec))
                return ResponseResult.NotFound<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // check user can be updated
            ISpecification<User> duplicatedUserNameSpec = _specificationsFactory.CreateUserSpecifications(typeof(CheckIfUserNameDuplicatedSpecification), request.dto.Id, request.dto.UserName);
            if (await _context.Users.AnyAsync(duplicatedUserNameSpec))
                return ResponseResult.BadRequest<GetUserDto>(message: _stringLocalizer[ResourcesKeys.User.UserNameIsExist]);


            ISpecification<User> getUserByIdSpec = _specificationsFactory.CreateUserSpecifications(typeof(GetUserByIdSpecification), request.dto.Id);
            User user = await _context.Users.RetrieveAsync(getUserByIdSpec);
            user.FirstName = request.dto.FirstName;
            user.LastName = request.dto.LastName;
            user.UserName = request.dto.UserName;
            user.UpdatedAt = DateTime.Now;
            // update user
            await _context.SaveChangesAsync();

            GetUserDto distenation = _mapper.Map<GetUserDto>(user);
            return ResponseResult.Success(distenation, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
