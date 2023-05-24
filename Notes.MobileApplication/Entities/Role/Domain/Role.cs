using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Notes.MobileApplication.Interfaces.Haves;

namespace Notes.MobileApplication.Entities.Role.Domain;

/// <summary>
/// Class Role.
/// Implements the <see cref="IHaveId" />
/// Implements the <see cref="IHaveName" />
/// </summary>
/// <seealso cref="IHaveId" />
/// <seealso cref="IHaveName" />
[Serializable]
public class Role : IHaveId, IHaveName
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
    /// Gets or sets the authors.
    /// </summary>
    /// <value>The authors.</value>
    [JsonIgnore]
    public virtual List<Author.Domain.Author> Authors { get; set; }
}