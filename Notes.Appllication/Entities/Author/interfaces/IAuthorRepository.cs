using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.Author.Interfaces;

/// <summary>
/// Interface IAuthorRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
public interface IAuthorRepository : IBaseRepository<Domain.Author>
{

}