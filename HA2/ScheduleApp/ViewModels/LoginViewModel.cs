using CommunityToolkit.Mvvm.Input;
using System;
using ScheduleApp.Models;
using ScheduleApp.Services;
using ScheduleApp.Events;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ScheduleApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    [ObservableProperty]
    private string? loginMessage;

    [RelayCommand]
    public void AttemptLogin()
    {
        LoginMessage = null;

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            LoginMessage = "Please enter a username and password";
            return;
        }

        var login = AuthService.ValidateCredentials(Username, Password);
        switch (login)
        {
            case Teacher:
                ViewSwitch.Invoke("TeacherView");
                break;
            case Student:
                ViewSwitch.Invoke("StudentView");
                break;
            default:
                LoginMessage = "Invalid username or password";
                break;
        }

        Username = null;
        Password = null;

        return;
    }
}