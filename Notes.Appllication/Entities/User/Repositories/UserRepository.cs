using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.User.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.User.Repositories;

/// <summary>
/// Class UserRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.User.Domain.User}" />
/// Implements the <see cref="IUserRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.User.Domain.User}" />
/// <seealso cref="IUserRepository" />
public class UserRepository : BaseRepository<Domain.User>, IUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UserRepository(INotesDbContext? context) : base((DbContext)context!)
    {
    }
}