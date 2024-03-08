using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IRestaurantRepository : IAsyncRepository<Restaurant>
{
    /// <summary>
    /// Gets a list of Restaurants
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> GetRestaurants();
}