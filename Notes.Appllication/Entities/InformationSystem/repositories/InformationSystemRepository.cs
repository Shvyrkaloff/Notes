using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.InformationSystem.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.InformationSystem.Repositories;

/// <summary>
/// Class InformationSystemRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
/// Implements the <see cref="IInformationSystemRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
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