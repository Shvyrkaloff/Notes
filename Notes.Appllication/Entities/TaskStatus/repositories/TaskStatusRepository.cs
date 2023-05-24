using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.Task.Interfaces;
using Notes.Application.Entities.TaskStatus.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.TaskStatus.Repositories;

/// <summary>
/// Class TaskStatusRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// Implements the <see cref="ITaskStatusRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
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