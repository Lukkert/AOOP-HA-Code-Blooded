using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;

namespace ScheduleApp.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{
    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }
}
