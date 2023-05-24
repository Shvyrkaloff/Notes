using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Interfaces;
using Notes.MobileApplication.Interfaces.Haves;

namespace Notes.MobileApplication.Entities.Bases.Repositories;

/// <summary>
/// Class BaseRepository.
/// Implements the <see cref="IBaseRepository{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="IBaseRepository{T}" />
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IHaveId
{
    /// <summary>
    /// The context
    /// </summary>
    protected readonly DbContext? Context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    protected BaseRepository(DbContext? context)
    {
        Context = context;
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;T&gt;.</returns>
    public async Task<T?> GetById(int id)
    {
        if (Context != null) 
            return await Context.Set<T>().FindAsync(id);
        return null;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
    public async Task<IEnumerable<T>?> GetAll()
    {
        return await Context?.Set<T>().ToListAsync()!;
    }

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
    public Task<IEnumerable<T>?> Find(Expression<Func<T, bool>> expression)
    {
        return System.Threading.Tasks.Task.FromResult<IEnumerable<T>?>(Context?.Set<T>().Where(expression));
    }

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    public async System.Threading.Tasks.Task Add(T entity)
    {
        Context?.Set<T>().Add(entity);
        await Context?.SaveChangesAsync()!;
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    public async System.Threading.Tasks.Task Update(T entity)
    {
        Context?.Set<T>().Update(entity);
        await Context?.SaveChangesAsync()!;
    }

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    public async System.Threading.Tasks.Task Remove(T entity)
    {
        Context?.Set<T>().Remove(entity);
        await Context?.SaveChangesAsync()!;
    }
}