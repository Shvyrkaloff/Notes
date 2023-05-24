using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Author.Domain;
using Notes.Application.Entities.InformationSystem.Domain;
using Notes.Application.Entities.Priority.Domain;
using Notes.Application.Entities.Role.Domain;
using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.User.Domain;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.Application.Interfaces;

/// <summary>
/// Interface INotesDbContext
/// </summary>
public interface INotesDbContext
{
    /// <summary>
    /// Gets or sets the authors.
    /// </summary>
    /// <value>The authors.</value>
    DbSet<Author> Authors { get; set; }

    /// <summary>
    /// Gets or sets the information systems.
    /// </summary>
    /// <value>The information systems.</value>
    DbSet<InformationSystem> InformationSystems { get; set; }

    /// <summary>
    /// Gets or sets the priorities.
    /// </summary>
    /// <value>The priorities.</value>
    DbSet<Priority> Priorities { get; set; }

    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    /// <value>The roles.</value>
    DbSet<Role> Roles { get; set; }

    /// <summary>
    /// Gets or sets the tasks.
    /// </summary>
    /// <value>The tasks.</value>
    DbSet<CatalogTask> CatalogTasks { get; set; }

    /// <summary>
    /// Gets or sets the task statuses.
    /// </summary>
    /// <value>The task statuses.</value>
    DbSet<TaskStatus> TaskStatuses { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    DbSet<User> Users { get; set; }
}