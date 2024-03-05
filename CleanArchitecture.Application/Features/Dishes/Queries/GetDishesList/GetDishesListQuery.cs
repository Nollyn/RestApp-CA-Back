using MediatR;

namespace CleanArchitecture.Application.Features.Dishes.Queries.GetDishesList;

public class GetDishesListQuery : IRequest<List<DishesVm>>
{
    public int _RestaurantId { get; set; }

    public GetDishesListQuery(int restaurantId)
    {
        _RestaurantId = restaurantId;
    }
}