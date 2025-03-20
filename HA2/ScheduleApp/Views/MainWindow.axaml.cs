using System;
using Avalonia.Controls;
using ScheduleApp.Services;

namespace ScheduleApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Closing += (sender, e) => DataStoreService.Save();
    }

   
}