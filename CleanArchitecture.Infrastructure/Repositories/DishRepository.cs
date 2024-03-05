using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class DishRepository : RepositoryBase<Dish>, IDishRepository
{
    public DishRepository(AppDbContext context) : base(context){}
    
    public async Task<IEnumerable<Dish>> GetDishesByRestaurant(int restaurantId)
    {
        return await _context.Dishes.Where(d => d.RestaurantId == restaurantId).ToListAsync();
    }
}