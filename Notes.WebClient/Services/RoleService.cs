using Notes.Application.Entities.Role.Domain;
using Notes.WebClient.Services.Bases;

namespace Notes.WebClient.Services;

/// <summary>
/// Class RoleService.
/// Implements the <see cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.Role.Domain.Role}" />
/// </summary>
/// <seealso cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.Role.Domain.Role}" />
public class RoleService : BaseService<Role>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(Role).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public RoleService(HttpClient? httpClient) : base(httpClient)
    {
    }
}