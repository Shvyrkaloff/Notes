using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Notes.Mobile.Services;
using Notes.MobileApplication.Entities.Task.Domain;
using Notes.MobileApplication.Entities.User.Domain;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Mobile;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class TaskList : ContentPage
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
    private List<CatalogTask> CatalogTasks { get; set; }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public User User { get; set; }

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

    private async void ButtonExit_OnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void TaskBox_OnSelectedIndexChanged(object sender, EventArgs e)
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
                await DisplayAlert("Error", "Error", "OK");
                break;
        }
    }

    private async void ButtonAddTask_OnClicked(object sender, EventArgs e)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var taskAddWindow = scope.ServiceProvider.GetRequiredService<TaskAddWindow>();

        await Navigation.PushAsync(taskAddWindow);

        taskAddWindow.Task = new CatalogTask();
        taskAddWindow.Window = this;

        this.IsEnabled = false;

        taskAddWindow.IsVisible = true;
    }

    private async Task OpenTaskEditForm(object sender)
    {
        
    }

    private async void ButtonDeleteTask_OnClicked(object sender, EventArgs e)
    {
        await _taskService.DeleteAsync(((((Button)sender).BindingContext as CatalogTask)!).Id);

        ListTasks.ItemsSource = ((await _taskService.GetAllAsync())!).ToList();
    }

    private async void TaskList_OnAppearing(object sender, EventArgs e)
    {
        await GetAllCatalogTasks();

        ActualUser.IsEnabled = false;
        ActualUser.Text = $"{User.Username} ({User.Author?.Role?.Name})";
    }

    private async void ListTasks_OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var taskEditForm = scope.ServiceProvider.GetRequiredService<TaskEditForm>();

        if (e.Item is CatalogTask edited)
        {
            taskEditForm.Task = edited;
            taskEditForm.Page = this;

            await Navigation.PushAsync(taskEditForm);

            await taskEditForm.LoadingData();

            this.IsEnabled = false;

            taskEditForm.IsVisible = true;
        }
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