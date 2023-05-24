using System.DirectoryServices.ActiveDirectory;
using System.Net.Http;
using Notes.Desktop.Services.Bases;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.Desktop.Services;

/// <summary>
/// Class TaskStatusService.
/// Implements the <see cref="Domain.TaskStatus}" />
/// </summary>
/// <seealso cref="Domain.TaskStatus}" />
public class TaskStatusService : BaseService<TaskStatus>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(TaskStatus).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatusService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public TaskStatusService(HttpClient? httpClient) : base(httpClient)
    {
    }
}