using MasaTour.TouristJourenysManagement.Application.Features.Users.Commands;

namespace MasaTour.TouristJourenysManagement.Application.Features.Users.Validators;
public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public AddUserCommandValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
        AppValidation();
    }
    void AppValidation()
    {
        //RuleFor(command => command.dto.FirstName)
        //    .NotNull().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeNull])
        //    .NotEmpty().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeEmpty])
        //    .MaximumLength(255).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength])
        //    .MinimumLength(3).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength]);

        //RuleFor(command => command.dto.LastName)
        // .NotNull().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeNull])
        // .NotEmpty().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeEmpty])
        // .MaximumLength(255).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength])
        // .MinimumLength(3).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength]);

        //RuleFor(command => command.dto.Email)
        // .NotNull().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeNull])
        // .NotEmpty().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeEmpty])
        // .MaximumLength(255).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength])
        // .MinimumLength(3).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength])
        // .EmailAddress().WithMessage(_stringLocalizer[ResourcesKeys.User.EmailNotValid]);

        //RuleFor(command => command.dto.LastName)
        // .NotNull().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeNull])
        // .NotEmpty().WithMessage(_stringLocalizer[ResourcesKeys.User.FiledCanNotBeEmpty])
        // .MaximumLength(255).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength])
        // .MinimumLength(3).WithMessage(_stringLocalizer[ResourcesKeys.User.FiledLengthIsSmallerThanMinLength]);
    }
}

