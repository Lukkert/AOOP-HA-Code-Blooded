using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Views;
using ScheduleApp.Models;
using ScheduleApp.Services;
using ScheduleApp.Events;

namespace ScheduleApp.ViewModels;

public partial class PopupWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string message;
    public PopupWindowViewModel(string message)
    {
        Message = message;
    }
}