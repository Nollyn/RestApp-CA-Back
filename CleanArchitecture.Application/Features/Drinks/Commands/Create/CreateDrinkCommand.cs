using MediatR;

namespace CleanArchitecture.Application.Features.Drinks.Commands.Create
{
    public class CreateDrinkCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public int RestaurantId { get; set; }
    }
}
