using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Notes.Mobile.Services;
using Notes.MobileApplication.Entities.User.Domain;
using Xamarin.Forms;

namespace Notes.Mobile;

public partial class MainPage : ContentPage
{
    /// <summary>
    /// The user service
    /// </summary>
    private readonly UserService _userService;

    /// <summary>
    /// The service scope factory
    /// </summary>
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public MainPage(UserService userService, IServiceScopeFactory serviceScopeFactory)
    {
        _userService = userService;
        _serviceScopeFactory = serviceScopeFactory;
        InitializeComponent();

        TextBoxLogin.Text = "user1";
        TextBoxPassword.Text = "user1";

        Test();
    }

    private async void Test()
    {
        var result = await _userService.GetAllAsync();
    }

    private async void Button_OnClicked(object sender, EventArgs e)
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
                    await DisplayAlert("Уведомление","+", "Ok");
                    using var scope = _serviceScopeFactory.CreateScope();
                    var taskList = scope.ServiceProvider.GetRequiredService<TaskList>();
                    taskList.User = u;
                    await Navigation.PushAsync(taskList);
                }
                break;
            }
            else
            {
                DisplayAlert("Уведомление", "Неверный логин или пароль", "Ok");
            }
        }
    }
}