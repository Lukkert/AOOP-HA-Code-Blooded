using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using ScheduleApp.Services;
using ScheduleApp.Events;

namespace ScheduleApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Closing += (sender, e) => DataStoreService.Save();
        Events.Popup.OnPopup += HandlePopup;
    }

    private async void HandlePopup(string message)
    {
        var dialog = new PopupWindow(message);
        var owner = VisualRoot as Window;
        await dialog.ShowDialog<bool>(owner!);
    }
   
}