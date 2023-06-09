﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Notes.MobileApplication.Interfaces.Haves;

namespace Notes.MobileApplication.Entities.Bases.Interfaces;

/// <summary>
/// Interface IBaseRepository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseRepository<T> where T : class, IHaveId
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;T&gt;.</returns>
    Task<T?> GetById(int id);

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>Task&lt;IQueryable&lt;T&gt;&gt;.</returns>
    Task<IEnumerable<T>?> GetAll();

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>Task&lt;IEnumerable&lt;T&gt;&gt;.</returns>
    Task<IEnumerable<T>?> Find(Expression<Func<T, bool>> expression);

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    System.Threading.Tasks.Task Add(T entity);

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    System.Threading.Tasks.Task Update(T entity);

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    System.Threading.Tasks.Task Remove(T entity);
}