using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.User.Domain;
using Notes.MobileApplication.Entities.User.Interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.User.Repositories;

/// <summary>
/// Class UserRepository.
/// Implements the <see cref="User" />
/// Implements the <see cref="IUserRepository" />
/// </summary>
/// <seealso cref="User" />
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