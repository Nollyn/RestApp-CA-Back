using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Instance of Drink repository to be used by UnitOfWork repository
    /// </summary>
    IDrinkRepository DrinkRepository { get; }
    
    /// <summary>
    /// Instance of Dish repository to be used by UnitOfWork repository
    /// </summary>
    IDishRepository DishRepository { get; }
    
    /// <summary>
    /// Instance of the generic repository to be used by UnitOfWork repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
    
    /// <summary>
    /// Method to complete actions by UnitOfWork repository
    /// </summary>
    /// <returns></returns>
    Task<int> Complete();
}