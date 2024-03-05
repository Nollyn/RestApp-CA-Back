using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class DrinkRepository : RepositoryBase<Drink>, IDrinkRepository
{
    public DrinkRepository(AppDbContext context) : base(context){}
    public async Task<IEnumerable<Drink>> GetDrinksByRestaurant(int restaurantId)
    {
        return await _context.Drinks.Where(d => d.RestaurantId == restaurantId).ToListAsync();
    }
}