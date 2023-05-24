using Microsoft.EntityFrameworkCore;
using Notes.MobileApplication.Entities.Bases.Repositories;
using Notes.MobileApplication.Entities.InformationSystem.Domain;
using Notes.MobileApplication.Entities.InformationSystem.interfaces;
using Notes.MobileApplication.Interfaces;

namespace Notes.MobileApplication.Entities.InformationSystem.repositories;

/// <summary>
/// Class InformationSystemRepository.
/// Implements the <see cref="InformationSystem" />
/// Implements the <see cref="IInformationSystemRepository" />
/// </summary>
/// <seealso cref="InformationSystem" />
/// <seealso cref="IInformationSystemRepository" />
public class InformationSystemRepository: BaseRepository<Domain.InformationSystem>, IInformationSystemRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InformationSystemRepository"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public InformationSystemRepository(INotesDbContext? context) : base((DbContext)context!)
    {
    }
}