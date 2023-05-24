using AntDesign;
using Microsoft.AspNetCore.Components;
using Notes.Application.Entities.Author.Domain;
using Notes.Application.Entities.InformationSystem.Domain;
using Notes.Application.Entities.Priority.Domain;
using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.User.Domain;
using Notes.WebClient.Services;
using Notes.WebClient.Services.Bases;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.WebClient.Components;

/// <summary>
/// Class TaskList.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class TaskList
{
    #region INJECTIONS

    /// <summary>
    /// Gets or sets the modal service.
    /// </summary>
    /// <value>The modal service.</value>
    [Inject]
    private ModalService ModalService { get; set; } = null!;

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
    /// Gets or sets the navigation manager.
    /// </summary>
    /// <value>The navigation manager.</value>
    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message service.
    /// </summary>
    /// <value>The message service.</value>
    [Inject]
    private IMessageService MessageService { get; set; } = null!;

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
    /// Gets or sets the selected catalog task.
    /// </summary>
    /// <value>The selected catalog task.</value>
    private CatalogTask? SelectedCatalogTask { get; set; }

    /// <summary>
    /// Gets or sets the edited task.
    /// </summary>
    /// <value>The edited task.</value>
    private CatalogTask? EditedTask { get; set; }

    /// <summary>
    /// The catalog tasks
    /// </summary>
    private List<CatalogTask>? _catalogTasks = new();

    /// <summary>
    /// The grid
    /// </summary>
    private readonly ListGridType _grid = new()
    {
        Gutter = 16,
        Xs = 1,
        Sm = 2,
        Md = 4,
        Lg = 4,
        Xl = 6,
        Xxl = 3,
    };

    /// <summary>
    /// The placement
    /// </summary>
    private string _placement = "right";

    /// <summary>
    /// The visible
    /// </summary>
    private bool _visibleDrawer = false;

    /// <summary>
    /// The visible modal
    /// </summary>
    private bool _visibleModal = false;

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
    /// Gets or sets the deleted task.
    /// </summary>
    /// <value>The deleted task.</value>
    private static CatalogTask? DeletedTask { get; set; }

    /// <summary>
    /// The on ok
    /// </summary>
    private Func<ModalClosingEventArgs, Task> _onOk;

    /// <summary>
    /// Gets or sets a value indicating whether [asked switch].
    /// </summary>
    /// <value><c>true</c> if [asked switch]; otherwise, <c>false</c>.</value>
    private bool AskedSwitch { get; set; } = false;

    #endregion

    /// <summary>
    /// Deletes the task handler.
    /// </summary>
    private async Task DeleteTaskHandler()
    {
        if (DeletedTask != null)
        {
            var response = await TaskService.DeleteAsync(DeletedTask.Id);
            if (response.IsSuccessStatusCode)
            {
                await MessageService.Success("Deletion completed successfully.");
            }
            else
            {
                await MessageService.Error("Deletion failed.");
            }
        }
        StateHasChanged();
    }

    /// <summary>
    /// The on cancel
    /// </summary>
    private Func<ModalClosingEventArgs, Task> _onCancel = (e) =>
    {
        Console.WriteLine("Cancel");
        return Task.CompletedTask;
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskList" /> class.
    /// </summary>
    public TaskList()
    {
        _onOk = async (e) =>
        {
            await DeleteTaskHandler();

            Console.WriteLine("Ok");
        };
    }

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        //FillingTestCards();

        AuthorsList = (await AuthorService.GetAllAsync() ?? Array.Empty<Author>()).ToList();
        PriorityList = (await PriorityService.GetAllAsync() ?? Array.Empty<Priority>()).ToList();
        InformationSystemList = (await InformationSystemService.GetAllAsync() ?? Array.Empty<InformationSystem>()).ToList();
        TaskStatusList = (await TaskStatusService.GetAllAsync() ?? Array.Empty<TaskStatus>()).ToList();

        _catalogTasks?.AddRange(AskedSwitch
            ? ((await TaskService.GetAllAsync())!).Where(t => t.TaskAuthorId == CurrentUser?.AuthorId).ToList()
            : ((await TaskService.GetAllAsync())!).Where(t => t.TaskExecutorId == CurrentUser?.AuthorId).ToList());

        StateHasChanged();
    }

    /// <summary>
    /// Fillings the test cards.
    /// </summary>
    private void FillingTestCards()
    {
        _catalogTasks?.Add(new CatalogTask()
        {
            Id = 0,
            Name = "Lorem ipsum dolor sit amet.",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            InformationSystem = new InformationSystem()
            {
                Name = "Sed ut perspiciatis"
            },
            Priority = new Priority()
            {
                Name = "Sed ut perspiciatis"
            },
            TaskAuthor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            },
            TaskExecutor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            }
        });
        _catalogTasks?.Add(new CatalogTask()
        {
            Id = 1,
            Name = "Lorem ipsum dolor sit amet.",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            InformationSystem = new InformationSystem()
            {
                Name = "Sed ut perspiciatis"
            },
            Priority = new Priority()
            {
                Name = "Sed ut perspiciatis"
            },
            TaskAuthor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            },
            TaskExecutor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            }
        });
        _catalogTasks?.Add(new CatalogTask()
        {
            Id = 2,
            Name = "Lorem ipsum dolor sit amet.",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            InformationSystem = new InformationSystem()
            {
                Name = "Sed ut perspiciatis"
            },
            Priority = new Priority()
            {
                Name = "Sed ut perspiciatis"
            },
            TaskAuthor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            },
            TaskExecutor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            }
        });
        _catalogTasks?.Add(new CatalogTask()
        {
            Id = 3,
            Name = "Lorem ipsum dolor sit amet.",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            InformationSystem = new InformationSystem()
            {
                Name = "Sed ut perspiciatis"
            },
            Priority = new Priority()
            {
                Name = "Sed ut perspiciatis"
            },
            TaskAuthor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            },
            TaskExecutor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            }
        });
        _catalogTasks?.Add(new CatalogTask()
        {
            Id = 4,
            Name = "Lorem ipsum dolor sit amet.",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            DateCreated = DateTime.Now,
            DateUpdated = DateTime.Now,
            InformationSystem = new InformationSystem()
            {
                Name = "Sed ut perspiciatis"
            },
            Priority = new Priority()
            {
                Name = "Sed ut perspiciatis"
            },
            TaskAuthor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            },
            TaskExecutor = new Author()
            {
                Name = "Lorem ipsum dolor sit amet"
            }
        });
    }

    /// <summary>
    /// Closes this instance.
    /// </summary>
    private void Close()
    {
        this._visibleDrawer = false;
    }

    /// <summary>
    /// Opens this instance.
    /// </summary>
    /// <param name="catalogTask">The catalog task.</param>
    /// <returns>Task.</returns>
    private Task Open(CatalogTask catalogTask)
    {
        SelectedCatalogTask = catalogTask;
        this._visibleDrawer = true;
        StateHasChanged();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Edits the task.
    /// </summary>
    /// <param name="catalogTask">The catalog task.</param>
    /// <returns>Task.</returns>
    private Task EditTaskEnabled(CatalogTask? catalogTask)
    {
        EditedTask = catalogTask;
        _visibleModal = true;
        StateHasChanged();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <returns>Task.</returns>
    private Task HandleCancel()
    {
        _visibleModal = false;
        StateHasChanged();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Called when [finish].
    /// </summary>
    private async Task OnFinish()
    {
        
    }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    private async Task OnFinishFailed()
    {
        
    }

    /// <summary>
    /// Edits the task.
    /// </summary>
    private async Task EditTask()
    {
        if (EditedTask != null)
        {
            UpdatingDependentAttributes();

            var ret = await TaskService.UpdateAsync(EditedTask!);
            if (ret.IsSuccessStatusCode)
            {
                Console.WriteLine($"{EditedTask?.Id} {EditedTask?.Name} is updated.");
            }
        }

        _visibleModal = false;
        StateHasChanged();
    }

    /// <summary>
    /// Updatings the dependent attributes.
    /// </summary>
    private void UpdatingDependentAttributes()
    {
        if (EditedTask == null) 
            return;

        EditedTask.TaskAuthor = AuthorsList.Find(a => a.Id == EditedTask.TaskAuthorId);
        EditedTask.TaskExecutor = AuthorsList.Find(a => a.Id == EditedTask.TaskExecutorId);
        EditedTask.InformationSystem = InformationSystemList.Find(a => a.Id == EditedTask.InformationSystemId);
        EditedTask.Priority = PriorityList.Find(a => a.Id == EditedTask.PriorityId);
        EditedTask.TaskStatus = TaskStatusList.Find(a => a.Id == EditedTask.TaskStatusId);
    }

    /// <summary>
    /// Deletes the task.
    /// </summary>
    /// <param name="task">The task.</param>
    private void DeleteTask(CatalogTask task)
    {
        DeletedTask = task;
        ModalService?.Confirm(new ConfirmOptions()
        {
            Title = $"Are you sure delete this task {task.Id} {task.Name}?",
            Icon = _icon,
            Content = "Some descriptions",
            OnOk = _onOk,
            OnCancel = _onCancel,
            OkType = "danger"
        });
    }

    /// <summary>
    /// Askeds the switch checked changed.
    /// </summary>
    private async Task AskedSwitchCheckedChanged()
    {
        _catalogTasks = new List<CatalogTask>();
        _catalogTasks?.AddRange(((await TaskService.GetAllAsync())!).ToList());

        if (AskedSwitch)
        {
            _catalogTasks = _catalogTasks?.Where(t => t.TaskAuthorId == CurrentUser?.AuthorId).ToList();
            AskedSwitch = false;
        }
        else
        {
            _catalogTasks = _catalogTasks?.Where(t => t.TaskExecutorId == CurrentUser?.AuthorId).ToList();
            AskedSwitch = true;
        }
    }
}