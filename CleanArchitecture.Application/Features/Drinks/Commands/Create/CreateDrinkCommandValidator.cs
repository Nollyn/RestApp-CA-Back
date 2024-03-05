using FluentValidation;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Create;

public class CreateDrinkCommandValidator : AbstractValidator<CreateDrinkCommand>
{
    public CreateDrinkCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The lenght should not exceed 50 characters");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("You must enter a price")
            .NotNull();

        RuleFor(p => p.RestaurantId)
            .NotEmpty()
            .WithMessage("It should be created for a Restaurant");
    }
}