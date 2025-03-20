using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Views;
using ScheduleApp.Models;
using ScheduleApp.Services;
using ScheduleApp.Events;

namespace ScheduleApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl? currentView;

    private StudentView _studentView = new StudentView { DataContext = new StudentViewModel() };
    private TeacherView _teacherView = new TeacherView { DataContext = new TeacherViewModel() };
    private LoginView _loginView = new LoginView { DataContext = new LoginViewModel() };


    public MainWindowViewModel()
    {
        CurrentView = _loginView;
        
        DataStoreService.Load();

        ViewSwitch.OnViewSwitch += HandleViewChange;
    }

    public void SwitchToTeacherView()
    {
        CurrentView = _teacherView;

    }

    public void SwitchToStudentView()
    {
        CurrentView = _studentView;
    }

    public void SwitchToLoginView()
    {
        CurrentView = _loginView;
    }

    private void HandleViewChange(string viewName)
    {
        switch (viewName)
        {
            case "StudentView":
                SwitchToStudentView();
                break;
            case "TeacherView":
                SwitchToTeacherView();
                break;
            case "LoginView":
                SwitchToLoginView();
                break;
            default:
                break;
        }
    }

}