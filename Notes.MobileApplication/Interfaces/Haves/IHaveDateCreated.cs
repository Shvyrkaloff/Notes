using System;

namespace Notes.MobileApplication.Interfaces.Haves;

/// <summary>
/// Interface IHaveDateCreated
/// </summary>
public interface IHaveDateCreated
{
    /// <summary>
    /// Gets or sets the date created.
    /// </summary>
    /// <value>The date created.</value>
    public DateTime? DateCreated { get; set; }
}