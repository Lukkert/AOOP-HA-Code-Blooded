using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using HA2.ScheduleApp.Models;
using HA2.ScheduleApp.ViewModels;
using HA2.ScheduleApp.Views;
using ScheduleApp.Views;
using Avalonia;

namespace ScheduleApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase //-- INotifyPropertyChanged from System.ComponentModel --EventHandler 
{


    [ObservableProperty]
    private UserControl? currentView;

    private StudentView _studentView = new StudentView{DataContext=new StudentViewModel()};
    private TeacherView _teacherView = new TeacherView{DataContext=new TeacherViewModel()};
    private LoginWindow _loginWindow = new LoginWindow{DataContext=new LoginWindowViewModel()};

    //public IRelayCommand OpenTeacherViewCommand { get; }
    //public IRelayCommand OpenStudentViewCommand { get; }
    
    public MainWindowViewModel()
    {
  //this.OpenTeacherViewCommand = new AsyncRelayCommand(OpenTeacherView);
  //this.OpenStudentViewCommand = new AsyncRelayCommand(OpenStudentView);
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
    

}


   

