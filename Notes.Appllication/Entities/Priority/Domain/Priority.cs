﻿using Notes.Application.Interfaces.Haves;
using System.Text.Json.Serialization;

namespace Notes.Application.Entities.Priority.Domain;

/// <summary>
/// Class Priority.
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
public class Priority : IHaveId, IHaveName
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
    /// Gets or sets the tasks.
    /// </summary>
    /// <value>The tasks.</value>
    [JsonIgnore]
    public virtual List<Task.Domain.CatalogTask> Tasks { get; set; }
}