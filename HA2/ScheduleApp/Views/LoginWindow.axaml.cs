using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;
using HA2.ScheduleApp.ViewModels;

namespace HA2.ScheduleApp.Views;

public partial class LoginWindow : UserControl
{
    private LoginWindowViewModel ViewModel => (LoginWindowViewModel)DataContext;   
    public LoginWindow()
    {
        InitializeComponent();
    }
     private Window GetWindow()
        {
            return (Window)this.VisualRoot;
        }

}