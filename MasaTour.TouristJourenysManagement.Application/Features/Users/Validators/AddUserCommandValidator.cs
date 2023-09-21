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
    }
}

