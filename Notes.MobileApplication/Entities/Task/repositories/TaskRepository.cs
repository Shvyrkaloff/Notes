using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.Task.Domain;
using Notes.MobileApplication.Entities.Task.interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.Task.repositories;

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