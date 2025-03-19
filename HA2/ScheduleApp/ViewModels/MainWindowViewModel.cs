using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HA2.ScheduleApp.ViewModels;
using HA2.ScheduleApp.Views;
using ScheduleApp.Models;

namespace ScheduleApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl? currentView;

    private StudentView _studentView = new StudentView { DataContext = new StudentViewModel() };
    private TeacherView _teacherView = new TeacherView { DataContext = new TeacherViewModel() };
    private LoginWindow _loginWindow = new LoginWindow { DataContext = new LoginWindowViewModel() };


    public MainWindowViewModel()
    {
        InitializeData();
        CurrentView = _loginWindow;
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

    private void InitializeData()
    {
        DataStore.Load();
    }

}




