using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.Task.Interfaces;

/// <summary>
/// Interface ITaskRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Task.Domain.CatalogTask}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Task.Domain.CatalogTask}" />
public interface ITaskRepository : IBaseRepository<Domain.CatalogTask>
{

}