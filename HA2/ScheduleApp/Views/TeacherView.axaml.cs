using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;
using HA2.ScheduleApp.ViewModels;
namespace HA2.ScheduleApp.Views;

public partial class TeacherView : UserControl
{
    private TeacherViewModel ViewModel => (TeacherViewModel)DataContext;
    public TeacherView()
    
    {
        InitializeComponent();
    }

    private Window GetWindow()
        {
            return (Window)this.VisualRoot;
        }
}