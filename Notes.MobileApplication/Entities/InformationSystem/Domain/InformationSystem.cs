using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Notes.MobileApplication.BaseUsers;
using Notes.MobileApplication.Interfaces.Haves;

namespace Notes.MobileApplication.Entities.InformationSystem.Domain;

/// <summary>
/// Class InformationSystem.
/// Implements the <see cref="BaseUserCU" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCU" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
[Serializable]
public class InformationSystem : BaseUserCU, IHaveId, IHaveName
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