using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;
using ScheduleApp.Models;
using ScheduleApp.Services;
using ScheduleApp.Views;

namespace ScheduleApp.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{
    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }

    
    public ObservableCollection<Subject> Subjects { get; } = new()
    {
        new Subject("Math", "Math is fun", 1),
        
        
    };
}
