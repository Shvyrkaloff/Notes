using Notes.Application.Entities.User.Domain;

namespace Notes.Desktop.Services.Bases;

/// <summary>
/// Interface IUserAuthenticationService
/// </summary>
public interface IUserAuthenticationService
{
    /// <summary>
    /// Gets or sets the authorized user.
    /// </summary>
    /// <value>The authorized user.</value>
    public User? AuthorizedUser { get; set; }
}