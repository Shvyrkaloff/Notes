using Notes.Application.Entities.User.Domain;
using Notes.Application.Entities.User.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class UserController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.User.Domain.User, Notes.Application.Entities.User.Interfaces.IUserRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.User.Domain.User, Notes.Application.Entities.User.Interfaces.IUserRepository}" />
public class UserController : BaseController<User, IUserRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public UserController(IUserRepository repository) : base(repository)
    {
    }
}