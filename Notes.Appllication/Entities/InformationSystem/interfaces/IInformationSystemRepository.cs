using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.InformationSystem.Interfaces;

/// <summary>
/// Interface IInformationSystemRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
public interface IInformationSystemRepository: IBaseRepository<Domain.InformationSystem>
{

}