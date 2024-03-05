using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Drink : BaseDomainModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public int RestaurantId { get; set; }
    }
}
