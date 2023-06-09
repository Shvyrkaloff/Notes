﻿using System.Net.Http;
using Notes.Mobile.Services.Bases;
using Notes.MobileApplication.Entities.Priority.Domain;

namespace Notes.Mobile.Services;

/// <summary>
/// Class PriorityService.
/// Implements the <see cref="Priority" />
/// </summary>
/// <seealso cref="Priority" />
public class PriorityService : BaseService<Priority>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(Priority).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public PriorityService(HttpClient? httpClient) : base(httpClient)
    {
    }
}