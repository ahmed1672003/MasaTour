using MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
using MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Users;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResponseModel<GetUserDto>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public AddUserCommandHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }

    public async Task<ResponseModel<GetUserDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        EmailIsExistSpecification userNameSpec = new(request.dto.Email);

        if (await _context.Users.AnyAsync(userNameSpec, cancellationToken))
            return ResponseResult.BadRequest<GetUserDto>(message: _stringLocalizer[ResourcesKeys.User.EmailIsExist]);
        try
        {
            var user = _mapper.Map<User>(request.dto);
            var r = await _context.Identity.UserManager.CreateAsync(user, request.dto.Password);
            //await _context.Users.CreateAsync(user, cancellationToken);
            //var r = await _context.SaveChangesAsync(cancellationToken);
            return ResponseResult.Success<GetUserDto>();
        }
        catch
        {
            return ResponseResult.InternalServerError<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError]);
        }
    }
}
