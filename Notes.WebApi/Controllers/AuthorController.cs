using Notes.Application.Entities.Author.Domain;
using Notes.Application.Entities.Author.Interfaces;
using Notes.WebApi.Controllers.Bases;

namespace Notes.WebApi.Controllers;

/// <summary>
/// Class AuthorController.
/// Implements the <see cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Author.Domain.Author, Notes.Application.Entities.Author.Interfaces.IAuthorRepository}" />
/// </summary>
/// <seealso cref="Notes.WebApi.Controllers.Bases.BaseController{Notes.Application.Entities.Author.Domain.Author, Notes.Application.Entities.Author.Interfaces.IAuthorRepository}" />
public class AuthorController : BaseController<Author, IAuthorRepository>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorController"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public AuthorController(IAuthorRepository repository) : base(repository)
    {

    }
}