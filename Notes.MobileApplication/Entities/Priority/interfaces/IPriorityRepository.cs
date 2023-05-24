using Notes.MobileApplication.Entities.Bases.Interfaces;

namespace Notes.MobileApplication.Entities.Priority.interfaces;

/// <summary>
/// Interface IPriorityRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Priority.Domain.Priority}" />
public interface IPriorityRepository : IBaseRepository<Domain.Priority>
{

}