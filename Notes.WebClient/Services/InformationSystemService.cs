using Notes.Application.Entities.InformationSystem.Domain;
using Notes.WebClient.Services.Bases;

namespace Notes.WebClient.Services;

/// <summary>
/// Class InformationSystemService.
/// Implements the <see cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
/// </summary>
/// <seealso cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.InformationSystem.Domain.InformationSystem}" />
public class InformationSystemService : BaseService<InformationSystem>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(InformationSystem).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="InformationSystemService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public InformationSystemService(HttpClient? httpClient) : base(httpClient)
    {
    }
}