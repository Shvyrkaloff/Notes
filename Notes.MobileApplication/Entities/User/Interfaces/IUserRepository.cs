using Notes.MobileApplication.Entities.Bases.Interfaces;

namespace Notes.MobileApplication.Entities.User.Interfaces;

/// <summary>
/// Interface IUserRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.User.Domain.User}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.User.Domain.User}" />
public interface IUserRepository : IBaseRepository<Domain.User>
{
}