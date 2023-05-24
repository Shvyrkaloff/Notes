using Notes.MobileApplication.BaseUsers;
using Notes.MobileApplication.Interfaces.Haves;
using System;

namespace Notes.MobileApplication.Entities.TaskStatus.Domain;

/// <summary>
/// Class TaskStatus.
/// Implements the <see cref="BaseUserCU" />
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="BaseUserCU" />
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
[Serializable]
public class TaskStatus: BaseUserCU, IHaveId, IHaveName
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
}