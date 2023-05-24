using Notes.Application.Entities.Priority.Domain;
using Notes.WebClient.Services.Bases;

namespace Notes.WebClient.Services;

/// <summary>
/// Class PriorityService.
/// Implements the <see cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.Priority.Domain.Priority}" />
/// </summary>
/// <seealso cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.Priority.Domain.Priority}" />
public class PriorityService : BaseService<Priority>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(Priority).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public PriorityService(HttpClient? httpClient) : base(httpClient)
    {
    }
}