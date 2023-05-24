using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.Priority.Domain;
using Notes.MobileApplication.Entities.Priority.interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.Priority.repositories;

/// <summary>
/// Class PriorityRepository.
/// Implements the <see cref="Priority" />
/// Implements the <see cref="IPriorityRepository" />
/// </summary>
/// <seealso cref="Priority" />
/// <seealso cref="IPriorityRepository" />
public class PriorityRepository : BaseRepository<Domain.Priority>, IPriorityRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public PriorityRepository(INotesDbContext? context) : base((DbContext)context!)
    {

    }
}