using Notes.Application.Entities.Bases.Interfaces;

namespace Notes.Application.Entities.User.Interfaces;

/// <summary>
/// Interface IUserRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.User.Domain.User}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.User.Domain.User}" />
public interface IUserRepository : IBaseRepository<Domain.User>
{
}