using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;
using System.Windows;
using Notes.Desktop.Services;
using Notes.Desktop.Windows;

namespace Notes.Desktop;

/// <summary>
/// Class App.
/// Implements the <see cref="Application" />
/// </summary>
/// <seealso cref="Application" />
public partial class App : System.Windows.Application
{
    /// <summary>
    /// The service provider
    /// </summary>
    private readonly ServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App" /> class.
    /// </summary>
    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<TaskList>();
        services.AddSingleton<TaskEditForm>();
        services.AddSingleton<TaskAddWindow>();

        services.AddScoped<UserService>();
        services.AddScoped<TaskService>();
        services.AddScoped<AuthorService>();
        services.AddScoped<InformationSystemService>();
        services.AddScoped<PriorityService>();
        services.AddScoped<RoleService>();
        services.AddScoped<TaskStatusService>();

        services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7033")
        });
    }

    /// <summary>
    /// Handles the <see cref="E:Startup" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="StartupEventArgs" /> instance containing the event data.</param>
    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow?.Show();
    }
}