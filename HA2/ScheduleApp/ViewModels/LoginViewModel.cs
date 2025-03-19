using CommunityToolkit.Mvvm.Input;
using System;
using ScheduleApp.Models;
using ScheduleApp.Events;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ScheduleApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? username;

    [ObservableProperty]
    private string? password;

    [RelayCommand]
    public void AttemptLogin()
    {
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
                Console.WriteLine("What happened here?");
                break;
        }
        Console.WriteLine($"Current User - {AuthService.CurrentUser}");
        return;
    }
}