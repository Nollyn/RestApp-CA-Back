namespace CleanArchitecture.Application.Features.Drinks.Queries.GetDrinksList
{
    public class DrinksVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public byte[] Image { get; set; } = null!;
        public int RestaurantId { get; set; }
    }
}
