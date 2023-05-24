using Microsoft.Extensions.DependencyInjection;
using Notes.Mobile.Services;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace Notes.Mobile;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        InitializeComponent();
        

        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainPage>();
            services.AddSingleton<TaskAddWindow>();
            services.AddSingleton<TaskEditForm>();
            services.AddSingleton<TaskList>();

            services.AddScoped<UserService>();
            services.AddScoped<TaskService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<InformationSystemService>();
            services.AddScoped<PriorityService>();
            services.AddScoped<RoleService>();
            services.AddScoped<TaskStatusService>();

            services.AddTransient(sp => new HttpClient
            {
                //BaseAddress = new Uri("https://localhost:7033")
                BaseAddress = new Uri("http://localhost:5107")
            });
        }
    

    protected override void OnStart()
    {
        MainPage = new NavigationPage(_serviceProvider.GetService<MainPage>());
        
    }
    
    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
}