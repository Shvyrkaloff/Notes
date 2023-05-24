using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Entities.Role.Interfaces;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.Role.Repositories;

/// <summary>
/// Class RoleRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
/// Implements the <see cref="IRoleRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
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