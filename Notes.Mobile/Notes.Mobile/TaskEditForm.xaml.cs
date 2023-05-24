using Microsoft.Extensions.DependencyInjection;
using Notes.Mobile.Services;
using Notes.MobileApplication.Entities.Author.Domain;
using Notes.MobileApplication.Entities.InformationSystem.Domain;
using Notes.MobileApplication.Entities.Priority.Domain;
using Notes.MobileApplication.Entities.Task.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Mobile;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TaskEditForm : ContentPage
{
    /// <summary>
    /// The task service
    /// </summary>
    private readonly TaskService _taskService;

    /// <summary>
    /// The author service
    /// </summary>
    private readonly AuthorService _authorService;

    /// <summary>
    /// The user service
    /// </summary>
    private readonly UserService _userService;

    /// <summary>
    /// The information system service
    /// </summary>
    private readonly InformationSystemService _informationSystemService;

    /// <summary>
    /// The priority service
    /// </summary>
    private readonly PriorityService _priorityService;

    /// <summary>
    /// The role service
    /// </summary>
    private readonly RoleService _roleService;

    /// <summary>
    /// The task status service
    /// </summary>
    private readonly TaskStatusService _taskStatusService;

    /// <summary>
    /// Gets or sets the task.
    /// </summary>
    /// <value>The task.</value>
    public CatalogTask? Task { get; set; }

    /// <summary>
    /// Gets or sets the window.
    /// </summary>
    /// <value>The window.</value>
    public Page? Page { get; set; }

    /// <summary>
    /// Gets or sets the authors list.
    /// </summary>
    /// <value>The authors list.</value>
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

    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    /// Gets or sets the task status list.
    /// </summary>
    /// <value>The task status list.</value>
    private List<MobileApplication.Entities.TaskStatus.Domain.TaskStatus> TaskStatusList { get; set; } = new();

    public TaskEditForm(TaskService taskService, AuthorService authorService, UserService userService, InformationSystemService informationSystemService, PriorityService priorityService, RoleService roleService, TaskStatusService taskStatusService, IServiceScopeFactory serviceScopeFactory)
    {
        _taskService = taskService;
        _authorService = authorService;
        _userService = userService;
        _informationSystemService = informationSystemService;
        _priorityService = priorityService;
        _roleService = roleService;
        _taskStatusService = taskStatusService;
        _serviceScopeFactory = serviceScopeFactory;

        InitializeComponent();
    }

    public async Task LoadingData()
    {
        TaskEditGrid.BindingContext = (object)Task!;

        AuthorsList = ((await _authorService.GetAllAsync())!).ToList();
        PriorityList = ((await _priorityService.GetAllAsync())!).ToList();
        InformationSystemList = ((await _informationSystemService.GetAllAsync())!).ToList();
        TaskStatusList = (await _taskStatusService.GetAllAsync())!.ToList();

        ComboBoxTaskAuthor.ItemsSource = AuthorsList;
        ComboBoxTaskExecutor.ItemsSource = AuthorsList;
        ComboBoxInformationSystem.ItemsSource = InformationSystemList;
        ComboBoxPriority.ItemsSource = PriorityList;
        ComboBoxTaskStatus.ItemsSource = TaskStatusList;

        ComboBoxTaskAuthor.SelectedItem =
            ((List<Author>)ComboBoxTaskAuthor.ItemsSource).Find(p =>
                Task != null && p.Id == Task.TaskAuthorId);
        ComboBoxTaskExecutor.SelectedItem =
            ((List<Author>)ComboBoxTaskExecutor.ItemsSource).Find(p =>
                Task != null && p.Id == Task.TaskExecutorId);
        ComboBoxInformationSystem.SelectedItem =
            ((List<InformationSystem>)ComboBoxInformationSystem.ItemsSource).Find(p =>
                Task != null && p.Id == Task.InformationSystemId);
        ComboBoxPriority.SelectedItem =
            ((List<Priority>)ComboBoxPriority.ItemsSource).Find(p =>
                Task != null && p.Id == Task.PriorityId);
        ComboBoxTaskStatus.SelectedItem =
            ((List<MobileApplication.Entities.TaskStatus.Domain.TaskStatus>)ComboBoxTaskStatus.ItemsSource).Find(p =>
                Task != null && p.Id == Task.TaskStatusId);
    }

    private void ButtonBack_OnClicked(object sender, EventArgs e)
    {
        _ = TaskEditWindowClosed();
    }
    private async Task TaskEditWindowClosed()
    {
        Page!.IsEnabled = true;
        
        await Navigation.PopAsync();
    }

    private async void ButtonSave_OnClicked(object sender, EventArgs e)
    {
        await _taskService.UpdateAsync(Task!);
        await TaskEditWindowClosed();
    }

    private async void ButtonDelete_OnClicked(object sender, EventArgs e)
    {
        if (Task != null) await _taskService.DeleteAsync(Task.Id);

        await Navigation.PopAsync();
    }
}