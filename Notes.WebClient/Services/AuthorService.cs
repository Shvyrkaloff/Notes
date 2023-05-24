using Notes.Application.Entities.Author.Domain;
using Notes.WebClient.Services.Bases;

namespace Notes.WebClient.Services;

/// <summary>
/// Class AuthorService.
/// Implements the <see cref="Bases.BaseService{Notes.Application.Entities.Author.Domain.Author}" />
/// </summary>
/// <seealso cref="Bases.BaseService{Notes.Application.Entities.Author.Domain.Author}" />
public class AuthorService : BaseService<Author>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(Author).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public AuthorService(HttpClient? httpClient) : base(httpClient)
    {
    }
}