using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.TaskStatus.interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.TaskStatus.repositories;

/// <summary>
/// Class TaskStatusRepository.
/// Implements the <see cref="MediaTypeNames.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// Implements the <see cref="ITaskStatusRepository" />
/// </summary>
/// <seealso cref="MediaTypeNames.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// <seealso cref="ITaskStatusRepository" />
public class TaskStatusRepository : BaseRepository<Domain.TaskStatus>, ITaskStatusRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatusRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public TaskStatusRepository(INotesDbContext? context) : base((DbContext)context!)
    {

    }
}