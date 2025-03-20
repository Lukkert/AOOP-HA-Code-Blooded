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

        //DataStoreService.Teachers.Add(Teacher.Create("John", "1111"));
        //DataStoreService.Students.Add(Student.Create("Klaus", "2222"));
        //DataStoreService.Save();

        DataStoreService.Load();

        ViewSwitch.OnViewSwitch += HandleViewChange;
    }

    [RelayCommand]
    public void NavigateToTeacherView()
    {
        CurrentView = _teacherView;

    }

    [RelayCommand]
    public void NavigateToStudentView()
    {
        CurrentView = _studentView;
    }

        public void NavigateToLoginView()
    {
        CurrentView = _loginView;
    }

    private void HandleViewChange(string viewName)
    {
        switch (viewName)
        {
            case "StudentView":
                NavigateToStudentView();
                break;
            case "TeacherView":
                NavigateToTeacherView();
                break;
            case "LoginView":
                NavigateToLoginView();
                break;
            default:
                break;
        }
    }

}