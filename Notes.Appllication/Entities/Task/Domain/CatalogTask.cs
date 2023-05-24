using Notes.Application.BaseUsers;
using Notes.Application.Interfaces.Haves;
using System.Text.Json.Serialization;

namespace Notes.Application.Entities.Task.Domain;

/// <summary>
/// Class CatalogTask.
/// Implements the <see cref="BaseUserCU" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCU" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
public class CatalogTask : BaseUserCU, IHaveId, IHaveName
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>The description.</value>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the task author identifier.
    /// </summary>
    /// <value>The task author identifier.</value>
    public int? TaskAuthorId { get; set; }

    /// <summary>
    /// Gets or sets the task author.
    /// </summary>
    /// <value>The task author.</value>
    public virtual Author.Domain.Author? TaskAuthor { get; set; }

    /// <summary>
    /// Gets or sets the task executor identifier.
    /// </summary>
    /// <value>The task executor identifier.</value>
    public int? TaskExecutorId { get; set; }

    /// <summary>
    /// Gets or sets the task executor.
    /// </summary>
    /// <value>The task executor.</value>
    public virtual Author.Domain.Author? TaskExecutor { get; set; }

    /// <summary>
    /// Gets or sets the information system identifier.
    /// </summary>
    /// <value>The information system identifier.</value>
    public int? InformationSystemId { get; set; }

    /// <summary>
    /// Gets or sets the information system.
    /// </summary>
    /// <value>The information system.</value>
    public virtual InformationSystem.Domain.InformationSystem? InformationSystem { get; set; }

    /// <summary>
    /// Gets or sets the priority identifier.
    /// </summary>
    /// <value>The priority identifier.</value>
    public int? PriorityId { get; set; }

    /// <summary>
    /// Gets or sets the priority.
    /// </summary>
    /// <value>The priority.</value>
    public virtual Priority.Domain.Priority? Priority { get; set; }

    /// <summary>
    /// Gets or sets the task status identifier.
    /// </summary>
    /// <value>The task status identifier.</value>
    public int? TaskStatusId { get; set; }

    /// <summary>
    /// Gets or sets the task status.
    /// </summary>
    /// <value>The task status.</value>
    public virtual TaskStatus.Domain.TaskStatus? TaskStatus { get; set; }
}