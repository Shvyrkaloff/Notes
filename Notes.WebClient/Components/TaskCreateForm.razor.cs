using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Notes.Application.Entities.Author.Domain;
using Notes.Application.Entities.InformationSystem.Domain;
using Notes.Application.Entities.Priority.Domain;
using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.User.Domain;
using Notes.WebClient.Services;
using Notes.WebClient.Services.Bases;
using System.Text.Json;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.WebClient.Components;

/// <summary>
/// Class TaskCreateForm.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class TaskCreateForm
{
    #region INJECTIONS

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>The message.</value>
    [Inject] 
    private IMessageService Message { get; set; } = null!;

    /// <summary>
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    /// <summary>
    /// Gets or sets the task service.
    /// </summary>
    /// <value>The task service.</value>
    [Inject]
    private TaskService TaskService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the task status service.
    /// </summary>
    /// <value>The task status service.</value>
    [Inject]
    private TaskStatusService TaskStatusService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the role service.
    /// </summary>
    /// <value>The role service.</value>
    [Inject]
    private RoleService RoleService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the priority service.
    /// </summary>
    /// <value>The priority service.</value>
    [Inject]
    private PriorityService PriorityService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the information system service.
    /// </summary>
    /// <value>The information system service.</value>
    [Inject]
    private InformationSystemService InformationSystemService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the author service.
    /// </summary>
    /// <value>The author service.</value>
    [Inject]
    private AuthorService AuthorService { get; set; } = null!;

    /// <summary>
    /// Gets or sets the user authentication service.
    /// </summary>
    /// <value>The user authentication service.</value>
    [Inject]
    private IUserAuthenticationService UserAuthenticationService { get; set; } = null!;

    #endregion

    #region PROPERTY

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <value>The current user.</value>
    private User? CurrentUser => UserAuthenticationService.AuthorizedUser;

    /// <summary>
    /// Gets or sets the created catalog task.
    /// </summary>
    /// <value>The created catalog task.</value>
    private CatalogTask CreatedCatalogTask { get; set; } = new();

    /// <summary>
    /// Gets or sets the authors.
    /// </summary>
    /// <value>The authors.</value>
    private List<Author> AuthorsList { get; set; } = new();

    /// <summary>
    /// Gets or sets the priority list.
    /// </summary>
    /// <value>The priority list.</value>
    private List<Priority> PriorityList { get; set; } = new();

    /// <summary>
    /// Gets or sets the information system list.
    /// </summary>
    /// <value>The information system list.</value>
    private List<InformationSystem> InformationSystemList { get; set; } = new();

    /// <summary>
    /// Gets or sets the task status list.
    /// </summary>
    /// <value>The task status list.</value>
    private List<TaskStatus> TaskStatusList { get; set; } = new();

    /// <summary>
    /// Gets or sets the default status.
    /// </summary>
    /// <value>The default status.</value>
    private TaskStatus? DefaultStatus { get; set; } = new();

    #endregion

    /// <summary>
    /// Method invoked when the component is ready to start, having received its
    /// initial parameters from its parent in the render tree.
    /// Override this method if you will perform an asynchronous operation and
    /// want the component to refresh when that operation is completed.
    /// </summary>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        AuthorsList = (await AuthorService.GetAllAsync() ?? Array.Empty<Author>()).ToList();
        PriorityList = (await PriorityService.GetAllAsync() ?? Array.Empty<Priority>()).ToList();
        InformationSystemList = (await InformationSystemService.GetAllAsync() ?? Array.Empty<InformationSystem>()).ToList();
        TaskStatusList = (await TaskStatusService.GetAllAsync() ?? Array.Empty<TaskStatus>()).ToList();

        DefaultStatus = TaskStatusList.FirstOrDefault();
    }

    /// <summary>
    /// Creates the task.
    /// </summary>
    private async Task CreateTask()
    {
        CreatedCatalogTask.TaskAuthorId = CurrentUser?.AuthorId;
        CreatedCatalogTask.TaskStatusId = DefaultStatus?.Id;

        var ret = await TaskService.CreateAsync(CreatedCatalogTask);
        if (ret.IsSuccessStatusCode)
            await Message.Success("The task was successfully added.");

        CreatedCatalogTask = new CatalogTask();
    }

    /// <summary>
    /// Called when [finish].
    /// </summary>
    /// <param name="arg">The argument.</param>
    /// <returns>Task.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    private async Task OnFinish(EditContext arg)
    {
        Console.WriteLine($"Success:{JsonSerializer.Serialize(CreatedCatalogTask)}");
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="arg">The argument.</param>
    /// <returns>Task.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    private async Task OnFinishFailed(EditContext arg)
    {
        Console.WriteLine($"Failed:{JsonSerializer.Serialize(CreatedCatalogTask)}");
    }
}