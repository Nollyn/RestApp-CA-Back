using MediatR;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Update;

public class UpdateDrinkCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public byte[]? Image { get; set; }
    public int RestaurantId { get; set; }
}