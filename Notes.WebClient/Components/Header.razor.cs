using Microsoft.AspNetCore.Components;
using Notes.WebClient.Services.Bases;

namespace Notes.WebClient.Components;

/// <summary>
/// Class Header.
/// Implements the <see cref="Microsoft.AspNetCore.Components.ComponentBase" />
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
public partial class Header
{
    /// <summary>
    /// Gets or sets a value indicating whether [authentication visibility].
    /// </summary>
    /// <value><c>true</c> if [authentication visibility]; otherwise, <c>false</c>.</value>
    private bool AuthenticationVisibility { get; set; } = false;

    /// <summary>
    /// Gets or sets the user authentication service.
    /// </summary>
    /// <value>The user authentication service.</value>
    [Inject]
    private IUserAuthenticationService UserAuthenticationService { get; set; } = null!;

    /// <summary>
    /// Gets the name of the user authentication.
    /// </summary>
    /// <value>The name of the user authentication.</value>
    private string UserAuthenticationName => $"{UserAuthenticationService.AuthorizedUser?.Username ?? "Anonymous"} ({UserAuthenticationService.AuthorizedUser?.Author?.Role?.Name ?? "Anonymous"})";

    /// <summary>
    /// Logins the handler.
    /// </summary>
    private void LoginHandler()
    {
        AuthenticationVisibility = true;
    }
}