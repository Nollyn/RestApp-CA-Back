using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IDishRepository : IAsyncRepository<Dish>
    {
        /// <summary>
        /// Gets a list of Restaurant Dishes
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        Task<IEnumerable<Dish>> GetDishesByRestaurant(int restaurantId);
    }
}
