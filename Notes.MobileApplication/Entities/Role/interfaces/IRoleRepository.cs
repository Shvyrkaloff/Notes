using Notes.MobileApplication.Entities.Bases.Interfaces;

namespace Notes.MobileApplication.Entities.Role.interfaces;

/// <summary>
/// Interface IRoleRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Role.Domain.Role}" />
public interface IRoleRepository : IBaseRepository<Domain.Role>
{

}