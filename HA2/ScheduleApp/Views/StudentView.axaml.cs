using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;
using HA2.ScheduleApp.ViewModels;

namespace HA2.ScheduleApp.Views;

public partial class StudentView : UserControl
{
    private StudentViewModel ViewModel => (StudentViewModel)DataContext;
    public StudentView()
    {
        InitializeComponent();
    }

    private Window GetWindow()
        {
            return (Window)this.VisualRoot;
        }
}