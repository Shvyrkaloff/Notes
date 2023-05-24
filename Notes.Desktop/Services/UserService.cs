using System.Net.Http;
using Notes.Application.Entities.User.Domain;
using Notes.Desktop.Services.Bases;

namespace Notes.Desktop.Services;

/// <summary>
/// Class UserService.
/// Implements the <see cref="User" />
/// </summary>
/// <seealso cref="User" />
public class UserService : BaseService<User>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(User).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public UserService(HttpClient? httpClient) : base(httpClient)
    {
    }
}