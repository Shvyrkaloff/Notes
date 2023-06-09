﻿using Notes.WebClient.Services.Bases;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.WebClient.Services;

/// <summary>
/// Class TaskStatusService.
/// Implements the <see cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
/// </summary>
/// <seealso cref="Notes.WebClient.Services.Bases.BaseService{Notes.Application.Entities.TaskStatus.Domain.TaskStatus}" />
public class TaskStatusService : BaseService<TaskStatus>
{
    /// <summary>
    /// Gets the base path.
    /// </summary>
    /// <value>The base path.</value>
    protected override string BasePath => nameof(TaskStatus).ToLower();

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskStatusService" /> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public TaskStatusService(HttpClient? httpClient) : base(httpClient)
    {
    }
}