using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.Role.Interfaces;

/// <summary>
/// Interface IRoleRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
public interface IRoleRepository : IBaseRepository<Domain.Role>
{

}