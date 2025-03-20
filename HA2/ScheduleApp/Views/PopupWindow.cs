using Avalonia.Controls;
using Avalonia.Interactivity;
using ScheduleApp.ViewModels;

namespace ScheduleApp.Views;

public partial class PopupWindow : Window
{
    public PopupWindow()
    {
        InitializeComponent();
    }
    public PopupWindow(string message)
    {
        InitializeComponent();
        DataContext = new PopupWindowViewModel(message);
    }

    private void Confirm(object? s, RoutedEventArgs e)
    {
        Close(true);
    }

    private void Cancel(object? s, RoutedEventArgs e)
    {
        Close(false);
    }
}