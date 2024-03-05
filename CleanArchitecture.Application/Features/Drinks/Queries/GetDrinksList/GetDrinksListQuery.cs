using MediatR;

namespace CleanArchitecture.Application.Features.Drinks.Queries.GetDrinksList
{
    public class GetDrinksListQuery : IRequest<List<DrinksVm>>
    {
        public int _RestaurantId { get; set; }

        public GetDrinksListQuery(int restaurantId)
        {
            _RestaurantId = restaurantId;
        }
    }
}
