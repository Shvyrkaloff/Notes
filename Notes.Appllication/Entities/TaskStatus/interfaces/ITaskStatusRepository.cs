using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.TaskStatus.Interfaces;

/// <summary>
/// Interface ITaskStatusRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
public interface ITaskStatusRepository : IBaseRepository<Domain.TaskStatus>
{

}