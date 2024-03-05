using FluentValidation;

namespace CleanArchitecture.Application.Features.Dishes.Commands.Update;

public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
{
    public UpdateDishCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("The name is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The name lenght should not exceed 50 characters");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("You must enter a price")
            .NotNull();
    }
}