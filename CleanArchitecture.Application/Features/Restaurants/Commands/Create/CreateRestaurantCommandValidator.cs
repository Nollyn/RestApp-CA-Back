using FluentValidation;

namespace CleanArchitecture.Application.Features.Restaurants.Commands.Create;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");

        RuleFor(p => p.Address)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull();
        
        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");
        
        RuleFor(p => p.NIF)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");
        
        RuleFor(p => p.PostalCode)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");
        
        RuleFor(p => p.City)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");
        
        RuleFor(p => p.Country)
            .NotEmpty()
            .WithMessage("The field is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("The length should not exceed 50 characters");
    }
}