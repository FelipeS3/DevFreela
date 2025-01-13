using DevFreela.Application.Commands.InsertUser;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateUserValidator : AbstractValidator<InsertUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FullName)
            .NotEmpty()
            .WithMessage("O campo não pode ser vazio.")
            .MaximumLength(40)
            .WithMessage("Campo com no máximo 50 caracteres.");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email invalído.");


        RuleFor(u => u.BirthDate)
            .Must(d => d < DateTime.Now.AddYears(-18))
            .WithMessage("Deve ser maior de idade!");
    }
}