using Notes.MobileApplication.Entities.Bases.Interfaces;

namespace Notes.MobileApplication.Entities.Author.interfaces;

/// <summary>
/// Interface IAuthorRepository
/// Extends the <see cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
/// </summary>
/// <seealso cref="Notes.Application.Entities.Bases.Interfaces.IBaseRepository{Notes.Application.Entities.Author.Domain.Author}" />
public interface IAuthorRepository : IBaseRepository<Domain.Author>
{

}