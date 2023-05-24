using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.Task.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class CatalogTaskController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Task.Domain.CatalogTask, Notes.Application.Entities.Task.Interfaces.ITaskRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Task.Domain.CatalogTask, Notes.Application.Entities.Task.Interfaces.ITaskRepository}" />
public class CatalogTaskController : BaseController<CatalogTask, ITaskRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogTaskController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public CatalogTaskController(ITaskRepository repository) : base(repository)
    {

    }
}