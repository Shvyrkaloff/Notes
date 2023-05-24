using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Entities.Task.Domain;
using Notes.Application.Entities.User.Domain;
using Notes.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notes.Desktop.Windows;

/// <summary>
/// Class TaskList.
/// Implements the <see cref="Window" />
/// Implements the <see cref="System.Windows.Markup.IComponentConnector" />
/// </summary>
/// <seealso cref="Window" />
/// <seealso cref="System.Windows.Markup.IComponentConnector" />
public partial class TaskList : Window
{
    /// <summary>
    /// The task service
    /// </summary>
    private readonly TaskService _taskService;

    /// <summary>
    /// The service scope factory
    /// </summary>
    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    /// Gets or sets the catalog tasks.
    /// </summary>
    /// <value>The catalog tasks.</value>
    private List<CatalogTask>? CatalogTasks { get; set; }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public User User { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskList" /> class.
    /// </summary>
    /// <param name="taskService">The task service.</param>
    /// <param name="serviceScopeFactory">The service scope factory.</param>
    public TaskList(TaskService taskService, IServiceScopeFactory serviceScopeFactory)
    {
        _taskService = taskService;
        _serviceScopeFactory = serviceScopeFactory;

        InitializeComponent();

        TaskBox.ItemsSource = new[]
        {
            new Filter { Name = "I WAS ASKED"},
            new Filter { Name = "I ASKED"}
        };
    }

    /// <summary>
    /// Gets all catalog tasks.
    /// </summary>
    private async Task GetAllCatalogTasks()
    {
        CatalogTasks = (await _taskService.GetAllAsync() ?? Array.Empty<CatalogTask>()).ToList();
        ListTasks.ItemsSource = CatalogTasks;
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonExit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Handles the Loaded event of the Window control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await GetAllCatalogTasks();

        ActualUser.Text = $"{User.Username} ({User.Author?.Role?.Name})";
    }

    /// <summary>
    /// Opens the task edit form.
    /// </summary>
    /// <param name="sender">The sender.</param>
    private async Task OpenTaskEditForm(object sender)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var taskEditForm = scope.ServiceProvider.GetRequiredService<TaskEditForm>();

        if ((sender as Button)?.DataContext is CatalogTask edited)
        {
            taskEditForm.Task = edited;
            taskEditForm.Window = this;

            await taskEditForm.LoadingData();

            this.IsEnabled = false;

            taskEditForm.Visibility = Visibility.Visible;
        }
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonBase control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        await OpenTaskEditForm(sender);
    }

    /// <summary>
    /// Handles the OnSelectionChanged event of the TaskBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
    private async void TaskBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (TaskBox.SelectedIndex)
        {
            case 0:
                CatalogTasks = (await _taskService.GetAllAsync() ?? Array.Empty<CatalogTask>()).ToList();
                ListTasks.ItemsSource = CatalogTasks.Where(t => t.TaskExecutorId == User.Id);
                break;
            case 1:
                CatalogTasks = (await _taskService.GetAllAsync() ?? Array.Empty<CatalogTask>()).ToList();
                ListTasks.ItemsSource = CatalogTasks.Where(t => t.TaskAuthorId == User.Id);
                break;
            default:
                MessageBox.Show("Error");
                break;
        }
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonAddTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private void ButtonAddTask_OnClick(object sender, RoutedEventArgs e)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var taskAddWindow = scope.ServiceProvider.GetRequiredService<TaskAddWindow>();

        taskAddWindow.Task = new CatalogTask();
        taskAddWindow.Window = this;

        this.IsEnabled = false;

        taskAddWindow.Visibility = Visibility.Visible;
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonOpenTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
    private async void ButtonOpenTask_OnClick(object sender, RoutedEventArgs e)
    {
        await OpenTaskEditForm(sender);
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonDeleteTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void ButtonDeleteTask_OnClick(object sender, RoutedEventArgs e)
    {
        await _taskService.DeleteAsync(((((Button)sender).DataContext as CatalogTask)!).Id);

        ListTasks.ItemsSource = ((await _taskService.GetAllAsync())!).ToList();
    }
}

/// <summary>
/// Class Filter.
/// </summary>
public class Filter
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }
}