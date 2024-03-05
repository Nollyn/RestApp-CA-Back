using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IDrinkRepository : IAsyncRepository<Drink>
    {
        /// <summary>
        /// Gets a list of Restaurant Drinks
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        Task<IEnumerable<Drink>> GetDrinksByRestaurant(int restaurantId);
    }
}
