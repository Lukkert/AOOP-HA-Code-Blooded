
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;

namespace ScheduleApp.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }
}
