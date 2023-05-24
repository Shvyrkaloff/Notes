using Notes.Application.Entities.InformationSystem.Domain;
using Notes.Application.Entities.InformationSystem.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class InformationSystemController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.InformationSystem.Domain.InformationSystem, Notes.Application.Entities.InformationSystem.Interfaces.IInformationSystemRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.InformationSystem.Domain.InformationSystem, Notes.Application.Entities.InformationSystem.Interfaces.IInformationSystemRepository}" />
public class InformationSystemController : BaseController<InformationSystem, IInformationSystemRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InformationSystemController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public InformationSystemController(IInformationSystemRepository repository) : base(repository)
    {

    }
}