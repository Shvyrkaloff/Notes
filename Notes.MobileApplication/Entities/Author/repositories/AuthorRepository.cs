using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Author.Domain;
using Notes.MobileApplication.Entities.Author.interfaces;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.Author.repositories;

/// <summary>
/// Class AuthorRepository.
/// Implements the <see cref="Author" />
/// Implements the <see cref="IAuthorRepository" />
/// </summary>
/// <seealso cref="Author" />
/// <seealso cref="IAuthorRepository" />
public class AuthorRepository: BaseRepository<Domain.Author>, IAuthorRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public AuthorRepository(INotesDbContext? context) : base((DbContext)context!)
    {

    }
}