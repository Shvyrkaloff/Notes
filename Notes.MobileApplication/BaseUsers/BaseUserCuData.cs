using System;

namespace Notes.MobileApplication.BaseUsers;

/// <summary>
/// Class BaseUserCuData.
/// </summary>
[Serializable]
public class BaseUserCuData
{
    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public string? User { get; set; }

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTime? Date { get; set; }
}