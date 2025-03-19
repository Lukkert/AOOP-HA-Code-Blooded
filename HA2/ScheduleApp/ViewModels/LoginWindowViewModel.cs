using ScheduleApp.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using ScheduleApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HA2.ScheduleApp.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string? username;

    [RelayCommand]
    public void AttemptLogin()
    {
        Console.WriteLine(Username);
        return;
    }

}
