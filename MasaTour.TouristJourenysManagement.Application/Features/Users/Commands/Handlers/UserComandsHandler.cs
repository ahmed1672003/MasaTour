﻿namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Commands.Handlers;
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
            // check if user found
            ISpecification<User> userIdSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingUserIdIsExistSpecification), request.dto.Id);
            if (!await _context.Users.AnyAsync(userIdSpec))
                return ResponseResult.NotFound<GetUserDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // check duplicated UserName
            ISpecification<User> duplicatedUserNameSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingCheckIfUserNameDuplicatedSpecification), request.dto.Id, request.dto.UserName);
            if (await _context.Users.AnyAsync(duplicatedUserNameSpec))
                return ResponseResult.BadRequest<GetUserDto>(message: _stringLocalizer[ResourcesKeys.User.UserNameIsDuplicated]);

            // check duplicated Email
            ISpecification<User> duplicatedEmailSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingCheckIfEmailDuplicatedSpecification), request.dto.Id, request.dto.Email);
            if (await _context.Users.AnyAsync(duplicatedEmailSpec))
                return ResponseResult.BadRequest<GetUserDto>(message: _stringLocalizer[ResourcesKeys.User.EmailIsDuplicated]);

            // check duplicated PhoneNumber
            ISpecification<User> duplicatedPhoneNumberSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsNoTrackingCheckIfPhoneNumberDuplicatedSpecification), request.dto.Id, request.dto.PhoneNumber);
            if (await _context.Users.AnyAsync(duplicatedPhoneNumberSpec))
                return ResponseResult.BadRequest<GetUserDto>(message: _stringLocalizer[ResourcesKeys.User.PhoneNumberIsDuplicated]);

            // select user
            ISpecification<User> getUserByIdSpec = _specificationsFactory.CreateUserSpecifications(typeof(AsTrackingGetUserByIdSpecification), request.dto.Id);
            User user = await _context.Users.RetrieveAsync(getUserByIdSpec);
            user.UserName = request.dto.UserName;
            user.NormalizedUserName = request.dto.UserName.ToUpper();
            user.Email = request.dto.Email;
            user.NormalizedEmail = request.dto.Email.ToUpper();
            user.FirstName = request.dto.FirstName;
            user.LastName = request.dto.LastName;
            user.Nationality = request.dto.Nationality;
            user.PhoneNumber = request.dto.PhoneNumber;
            user.ImgSrc = request.dto.ImgSrc;
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
