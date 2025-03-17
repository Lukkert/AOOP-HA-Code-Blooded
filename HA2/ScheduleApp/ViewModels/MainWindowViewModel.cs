using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ScheduleApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase //-- INotifyPropertyChanged from System.ComponentModel --EventHandler 
{
    [ObservableProperty]
    public bool studentRadioButton = false;
    [ObservableProperty]
    public bool teacherRadioButton = false;

    
}
