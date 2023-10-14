using Microsoft.EntityFrameworkCore;

namespace MasaTour.TouristTripsManagement.Application.Features.Users.Queries.Handlers;
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

            IQueryable<User> query = await _context.Users.RetrieveAllAsync(userByIdSpec, cancellationToken);

            GetUserDto Dto = await query.Select(user => new GetUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                FileName = user.FileName,
                FilePath = user.FilePath,
                Gender = user.Gender,
                Nationality = user.Nationality,
                CreatedAt = user.CreatedAt,
                DeletedAt = user.DeletedAt,
                IsDeleted = user.IsDeleted,
                UpdatedAt = user.UpdatedAt,
            }).FirstOrDefaultAsync();

            return ResponseResult.Success(Dto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
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
            IQueryable<User> query = await _context.Users.RetrieveAllAsync(cancellationToken: cancellationToken);
            IQueryable<GetUserDto> Dtos = query.Select(user => new GetUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                FileName = user.FileName,
                FilePath = user.FilePath,
                Gender = user.Gender,
                Nationality = user.Nationality,
                CreatedAt = user.CreatedAt,
                DeletedAt = user.DeletedAt,
                IsDeleted = user.IsDeleted,
                UpdatedAt = user.UpdatedAt,
            });
            return ResponseResult.Success(Dtos.AsEnumerable(), message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
