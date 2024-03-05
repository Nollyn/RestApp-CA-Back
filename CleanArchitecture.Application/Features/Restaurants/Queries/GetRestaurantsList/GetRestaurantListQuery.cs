using MediatR;

namespace CleanArchitecture.Application.Features.Restaurants.Queries.GetRestaurantsList;

public class GetRestaurantListQuery : IRequest<List<RestaurantsVm>>
{
    public GetRestaurantListQuery()
    {
        
    }
}