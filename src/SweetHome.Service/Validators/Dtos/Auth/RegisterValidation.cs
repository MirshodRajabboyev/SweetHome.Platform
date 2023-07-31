using FluentValidation;
using SweetHome.Service.Dtos.Auth;

namespace SweetHome.Service.Validators.Dtos.Auth;

public class RegisterValidation : AbstractValidator<RegisterDto>
{
    public RegisterValidation()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Требуется имя!")
            .MaximumLength(30).WithMessage("Имя должно содержать менее 30 символов");

        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Требуется фамилия!")
            .MaximumLength(30).WithMessage("Фамилия должно содержать менее 30 символов");

        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
            .WithMessage("Номер телефона недействителен! Например: +998xxYYYAABB\"");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Пароль не надежный!");
    }
}
