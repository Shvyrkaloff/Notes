using System.Net.Http;
using Notes.Application.Entities.Task.Domain;
using Notes.Desktop.Services.Bases;

namespace Notes.Desktop.Services;

/// <summary>
/// Class TaskService.
/// Implements the <see cref="CatalogTask" />
/// </summary>
/// <seealso cref="CatalogTask" />
public class TaskService : BaseService<CatalogTask>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(CatalogTask).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public TaskService(HttpClient? httpClient) : base(httpClient)
    {
    }
}