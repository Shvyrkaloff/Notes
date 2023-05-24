using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.Role.Domain;
using Notes.MobileApplication.Entities.Role.interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.Role.repositories;

/// <summary>
/// Class RoleRepository.
/// Implements the <see cref="Role" />
/// Implements the <see cref="IRoleRepository" />
/// </summary>
/// <seealso cref="Role" />
/// <seealso cref="IRoleRepository" />
public class RoleRepository : BaseRepository<Domain.Role>, IRoleRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoleRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public RoleRepository(INotesDbContext? context) : base((DbContext)context!)
    {

    }
}