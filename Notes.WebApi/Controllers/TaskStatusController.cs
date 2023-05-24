using Notes.Application.Entities.TaskStatus.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class TaskStatusController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.TaskStatus.Domain.TaskStatus, Notes.Application.Entities.TaskStatus.Interfaces.ITaskStatusRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.TaskStatus.Domain.TaskStatus, Notes.Application.Entities.TaskStatus.Interfaces.ITaskStatusRepository}" />
public class TaskStatusController : BaseController<Notes.Application.Entities.TaskStatus.Domain.TaskStatus, ITaskStatusRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatusController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public TaskStatusController(ITaskStatusRepository repository) : base(repository)
    {

    }
}