using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.Task.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.Task.Repositories;

/// <summary>
/// Class TaskRepository.
/// Implements the <see cref="CatalogTask" />
/// Implements the <see cref="ITaskRepository" />
/// </summary>
/// <seealso cref="CatalogTask" />
/// <seealso cref="ITaskRepository" />
public class TaskRepository : BaseRepository<CatalogTask>, ITaskRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public TaskRepository(INotesDbContext? context) : base((DbContext)context!)
    {

    }
}