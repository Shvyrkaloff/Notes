using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Mobile.Services;
using Notes.MobileApplication.Entities.Author.Domain;
using Notes.MobileApplication.Entities.InformationSystem.Domain;
using Notes.MobileApplication.Entities.Priority.Domain;
using Notes.MobileApplication.Entities.Task.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaskStatus = Notes.MobileApplication.Entities.TaskStatus.Domain.TaskStatus;

namespace Notes.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskAddWindow : ContentPage
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
        public Page? Window { get; set; }

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
        public TaskAddWindow(TaskService taskService, AuthorService authorService, UserService userService, InformationSystemService informationSystemService, PriorityService priorityService, RoleService roleService, TaskStatusService taskStatusService)
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
        /// Tasks the add window closed.
        /// </summary>
        private async Task TaskAddWindowClosed()
        {
            Window!.IsEnabled = true;
            this.IsVisible = false;
        }

        private void ButtonBack_OnClicked(object sender, EventArgs e)
        {
            _ = TaskAddWindowClosed();
        }

        private async void ButtonSave_OnClicked(object sender, EventArgs e)
        {
            await CreateTask();

            //(((TaskList)Window!)!).ListTasks.ItemsSource = ((await _taskService.GetAllAsync())!).ToList();

            await TaskAddWindowClosed();
        }
        private async Task CreateTask()
        {
            Task = (CatalogTask?)TaskAddGrid.BindingContext;

            if (Task != null)
            {
                Task.InformationSystemId = Task.InformationSystem?.Id;
                Task.TaskAuthorId = Task.TaskAuthor?.Id;
                Task.TaskExecutorId = Task.TaskExecutor?.Id;
                Task.TaskStatusId = Task.TaskStatus?.Id;
                Task.PriorityId = Task.Priority?.Id;

                Task.InformationSystem = null;
                Task.TaskAuthor = null;
                Task.TaskExecutor = null;
                Task.TaskStatus = null;
                Task.Priority = null;

                await _taskService.CreateAsync(Task);
            }
            
            await Navigation.PopAsync();
        }

        private async void TaskAddWindow_OnAppearing(object sender, EventArgs e)
        {
            TaskAddGrid.BindingContext = (object)Task!;

            AuthorsList = ((await _authorService.GetAllAsync())!).ToList();
            PriorityList = ((await _priorityService.GetAllAsync())!).ToList();
            InformationSystemList = ((await _informationSystemService.GetAllAsync())!).ToList();
            TaskStatusList = ((await _taskStatusService.GetAllAsync())!).ToList();

            ComboBoxTaskAuthor.ItemsSource = AuthorsList;
            ComboBoxTaskExecutor.ItemsSource = AuthorsList;
            ComboBoxInformationSystem.ItemsSource = InformationSystemList;
            ComboBoxPriority.ItemsSource = PriorityList;
            ComboBoxTaskStatus.ItemsSource = TaskStatusList;
        }
    }
}