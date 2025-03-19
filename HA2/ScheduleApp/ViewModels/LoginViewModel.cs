using CommunityToolkit.Mvvm.Input;
using System;
using ScheduleApp.Models;
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
        foreach (var teacher in DataStore.Teachers)
        {
            if (Username == teacher.Name && Password == teacher.Password)
            {
                ViewSwitcher.SwitchView("TeacherView");
            }
        }
        foreach (var student in DataStore.Students)
        {
            if (Username == student.Name && Password == student.Password)
            {
                ViewSwitcher.SwitchView("StudentView");
            }
        }
        return;
    }

}
