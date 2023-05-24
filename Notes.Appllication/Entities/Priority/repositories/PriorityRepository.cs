using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.Priority.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.Priority.Repositories;

/// <summary>
/// Class PriorityRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
/// Implements the <see cref="IPriorityRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
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