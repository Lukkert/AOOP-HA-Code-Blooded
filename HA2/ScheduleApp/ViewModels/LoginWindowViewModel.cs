using ScheduleApp.ViewModels;
using CommunityToolkit.Mvvm.Input;
using System;
using ScheduleApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using Avalonia.Controls;

namespace HA2.ScheduleApp.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase
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
                Console.WriteLine(teacher);
            }
        }
        foreach (var student in DataStore.Students)
        {
            if (Username == student.Name && Password == student.Password)
            {
                Console.WriteLine(student);
            }
        }
        return;
    }

}
