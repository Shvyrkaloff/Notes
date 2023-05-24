using Notes.Application.Entities.Priority.Domain;
using Notes.Application.Entities.Priority.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class PriorityController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Priority.Domain.Priority, Notes.Application.Entities.Priority.Interfaces.IPriorityRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Priority.Domain.Priority, Notes.Application.Entities.Priority.Interfaces.IPriorityRepository}" />
public class PriorityController : BaseController<Priority, IPriorityRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public PriorityController(IPriorityRepository repository) : base(repository)
    {

    }
}