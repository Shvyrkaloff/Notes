﻿using Notes.Mobile.Services.Bases;
using Notes.MobileApplication.Entities.User.Domain;

namespace Notes.Mobile.Services;

/// <summary>
/// Class UserAuthenticationService.
/// Implements the <see cref="IUserAuthenticationService" />
/// </summary>
/// <seealso cref="IUserAuthenticationService" />
public class UserAuthenticationService : IUserAuthenticationService
{
    /// <summary>
    /// Gets or sets the authorized user.
    /// </summary>
    /// <value>The authorized user.</value>
    public User? AuthorizedUser { get; set; }
}