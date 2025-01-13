using DevFreela.Application.Commands.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
{
    public InsertProjectValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Não pode ser vazio.")
            .MaximumLength(50)
            .WithMessage("Tamanho máximo de 50 caracteres");

        RuleFor(p => p.TotalCost)
            .GreaterThanOrEqualTo(1000) 
            .WithMessage("O projeto deve custar no minimo R$1.000");

    }
}