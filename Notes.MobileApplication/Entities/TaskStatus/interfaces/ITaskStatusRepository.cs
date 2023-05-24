using Notes.MobileApplication.Entities.Bases.Interfaces;

namespace Notes.MobileApplication.Entities.TaskStatus.interfaces;

/// <summary>
/// Interface ITaskStatusRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
public interface ITaskStatusRepository : IBaseRepository<Domain.TaskStatus>
{

}