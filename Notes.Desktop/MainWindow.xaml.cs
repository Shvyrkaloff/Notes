using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Entities.User.Domain;
using Notes.Desktop.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Notes.Desktop.Windows;

namespace Notes.Desktop;

/// <summary>
/// Class MainWindow.
/// Implements the <see cref="Window" />
/// Implements the <see cref="System.Windows.Markup.IComponentConnector" />
/// </summary>
/// <seealso cref="Window" />
/// <seealso cref="System.Windows.Markup.IComponentConnector" />
public partial class MainWindow : Window
{
    /// <summary>
    /// The user service
    /// </summary>
    private readonly UserService _userService;

    /// <summary>
    /// The service scope factory
    /// </summary>
    private readonly IServiceScopeFactory _serviceScopeFactory;

    /// <summary>
    /// The users
    /// </summary>
    private readonly List<User?> _users;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    /// <param name="userService">The user service.</param>
    /// <param name="serviceScopeFactory">The service scope factory.</param>
    public MainWindow(UserService userService, IServiceScopeFactory serviceScopeFactory)
    {
        _userService = userService;
        _serviceScopeFactory = serviceScopeFactory;
        InitializeComponent();
    }

    /// <summary>
    /// Handles the OnClick event of the ButtonBase control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var users = ((await _userService.GetAllAsync())!).ToList();

        bool any = false;
        foreach (var u in users)
        {
            if (u?.Username == TextBoxLogin.Text && u?.Password == TextBoxPassword.Text)
            {
                any = true;
                if (any)
                {
                    MessageBox.Show("+");
                    using var scope = _serviceScopeFactory.CreateScope();
                    var taskList = scope.ServiceProvider.GetRequiredService<TaskList>();
                    taskList.User = u;

                    taskList.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                break;
            }
        }
    }
}