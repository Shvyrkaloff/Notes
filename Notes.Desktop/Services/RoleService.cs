using System.Net.Http;
using Notes.Application.Entities.Role.Domain;
using Notes.Desktop.Services.Bases;

namespace Notes.Desktop.Services;

/// <summary>
/// Class RoleService.
/// Implements the <see cref="Role" />
/// </summary>
/// <seealso cref="Role" />
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