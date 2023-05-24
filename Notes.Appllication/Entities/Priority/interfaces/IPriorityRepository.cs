using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.Priority.Interfaces;

/// <summary>
/// Interface IPriorityRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
public interface IPriorityRepository : IBaseRepository<Domain.Priority>
{

}