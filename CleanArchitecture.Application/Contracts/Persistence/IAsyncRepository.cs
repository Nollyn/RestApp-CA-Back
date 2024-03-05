using System.Linq.Expressions;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence;

/// <summary>
/// Represents the abstraction for the use cases implementation
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncRepository<T> where T : BaseDomainModel
{
    /// <summary>
    /// Generic method to Add/Create a new entity record using UnitOfWork
    /// </summary>
    /// <param name="entity"></param>
    void AddEntity(T entity);

    /// <summary>
    /// Generic method to update an entity record using UnitOfWork
    /// </summary>
    /// <param name="entity"></param>
    void UpdateEntity(T entity);

    /// <summary>
    /// Generic method to delete an entity record using UnitOfWork
    /// </summary>
    /// <param name="Entity"></param>
    void DeleteEntity(T Entity);
    
    /// <summary>
    /// Returns a list of all the records of an entity
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<T>> GetAllAsync();
    
    /// <summary>
    /// Gets an Entity by its Identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Returns a data collection given a logical condition
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Allows to order a list
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="orderBy"></param>
    /// <param name="includeString"></param>
    /// <param name="disableTraking"></param>
    /// <returns></returns>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeString = null,
        bool disableTraking = true);

    /// <summary>
    /// Allows pagination
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <param name="disableTraking"></param>
    /// <returns></returns>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<Expression<Func<T, object>>>? includes = null, bool disableTraking = true);
}