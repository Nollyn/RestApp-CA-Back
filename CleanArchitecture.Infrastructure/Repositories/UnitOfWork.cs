using System.Collections;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly AppDbContext _context;

    private IDrinkRepository _drinkRepository;
    private IDishRepository _dishRepository;
    private IRestaurantRepository _restaurantRepository;

    public IDrinkRepository DrinkRepository => _drinkRepository ??= new DrinkRepository(_context);
    public IDishRepository DishRepository => _dishRepository ??= new DishRepository(_context);
    public IRestaurantRepository RestaurantRepository => _restaurantRepository ??= new RestaurantRepository(_context);

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type)) return (IAsyncRepository<TEntity>) _repositories[type];
        var repositoryType = typeof(RepositoryBase<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
        _repositories.Add(type, repositoryInstance);

        return (IAsyncRepository<TEntity>)_repositories[type];
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }
}