using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Entities.Author.Interfaces;
using Notes.Application.Entities.Bases.Repositories;
using Notes.Application.Interfaces;

namespace Notes.Application.Entities.Author.Repositories;

/// <summary>
/// Class AuthorRepository.
/// Implements the <see cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
/// Implements the <see cref="IAuthorRepository" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Repositories.BaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
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