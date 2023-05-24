using Notes.Application.Entities.Author.Domain;
using Notes.Application.Entities.InformationSystem.Domain;
using Notes.Application.Entities.Priority.Domain;
using Notes.Application.Entities.Task.Domain;
using Notes.Desktop.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskStatus = Notes.Application.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.Desktop.Windows;

/// <summary>
/// Class TaskEditForm.
/// Implements the <see cref="System.Windows.Window" />
/// Implements the <see cref="System.Windows.Markup.IComponentConnector" />
/// </summary>
/// <seealso cref="System.Windows.Window" />
/// <seealso cref="System.Windows.Markup.IComponentConnector" />
public partial class TaskEditForm : Window
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
    public Window? Window { get; set; }

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

    /// <summary>
    /// Gets or sets the task status list.
    /// </summary>
    /// <value>The task status list.</value>
    private List<TaskStatus> TaskStatusList { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskEditForm" /> class.
    /// </summary>
    /// <param name="taskService">The task service.</param>
    /// <param name="authorService">The author service.</param>
    /// <param name="userService">The user service.</param>
    /// <param name="informationSystemService">The information system service.</param>
    /// <param name="priorityService">The priority service.</param>
    /// <param name="roleService">The role service.</param>
    /// <param name="taskStatusService">The task status service.</param>
    public TaskEditForm(TaskService taskService, AuthorService authorService, UserService userService, InformationSystemService informationSystemService, PriorityService priorityService, RoleService roleService, TaskStatusService taskStatusService)
    {
        _taskService = taskService;
        _authorService = authorService;
        _userService = userService;
        _informationSystemService = informationSystemService;
        _priorityService = priorityService;
        _roleService = roleService;
        _taskStatusService = taskStatusService;

        InitializeComponent();
    }

    /// <summary>
    /// Loadings the data.
    /// </summary>
    public async Task LoadingData()
    {
        TaskEditGrid.DataContext = (object)Task!;

        AuthorsList = ((await _authorService.GetAllAsync())!).ToList();
        PriorityList = ((await _priorityService.GetAllAsync())!).ToList();
        InformationSystemList = ((await _informationSystemService.GetAllAsync())!).ToList();
        TaskStatusList = ((await _taskStatusService.GetAllAsync())!).ToList();

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
            ((List<TaskStatus>)ComboBoxTaskStatus.ItemsSource).Find(p =>
                Task != null && p.Id == Task.TaskStatusId);
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
    {
        _ = TaskEditWindowClosed();
    }

    /// <summary>
    /// Tasks the edit window closed.
    /// </summary>
    private async Task TaskEditWindowClosed()
    {
        Window!.IsEnabled = true;
        this.Visibility = Visibility.Hidden;
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    private async void ButtonSave_OnClick(object sender, RoutedEventArgs e)
    {
        await _taskService.UpdateAsync(Task!);
        await TaskEditWindowClosed();
    }

    /// <summary>
    /// Handles the Loaded event of the Window control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadingData();
    }
}