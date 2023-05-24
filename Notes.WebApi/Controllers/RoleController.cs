using Notes.Application.Entities.Role.Domain;
using Notes.Application.Entities.Role.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class RoleController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Role.Domain.Role, Notes.Application.Entities.Role.Interfaces.IRoleRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Role.Domain.Role, Notes.Application.Entities.Role.Interfaces.IRoleRepository}" />
public class RoleController : BaseController<Role, IRoleRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public RoleController(IRoleRepository repository) : base(repository)
    {

    }
}