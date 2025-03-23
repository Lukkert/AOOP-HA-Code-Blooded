using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;
using ScheduleApp.Models;
using ScheduleApp.Services;

namespace ScheduleApp.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{
    public ObservableCollection<Subject>? Subjects { get; set; } = [];

    [ObservableProperty]
    private Subject? selectedSubject;

    [ObservableProperty]
    private string? newSubjectName;

    [ObservableProperty]
    private string? newSubjectDescription;

    [ObservableProperty]
    private string? teacherName;

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }

    [RelayCommand]
    public void CreateSubject()
    {
        if (string.IsNullOrEmpty(NewSubjectName) || string.IsNullOrEmpty(NewSubjectDescription))
        {
            Popup.Invoke("Please enter a name and description");
            return;
        }

        var teacher = AuthService.CurrentUser as Teacher;
        teacher!.CreateSubject(NewSubjectName, NewSubjectDescription);

        Update();
    }

    [RelayCommand]
    public void EditSubject()
    {
        if (SelectedSubject == null)
        {
            Popup.Invoke("Please select a subject.");
            return;
        }

        if (string.IsNullOrEmpty(NewSubjectName) || string.IsNullOrEmpty(NewSubjectDescription))
        {
            Popup.Invoke("Please enter a name and description");
            return;
        }

        var teacher = AuthService.CurrentUser as Teacher;
        teacher!.EditSubject(SelectedSubject, NewSubjectName, NewSubjectDescription);

        Update();
    }

    [RelayCommand]
    public void RemoveSubject()
    {
        if (SelectedSubject == null)
        {
            Popup.Invoke("Please select a subject.");
            return;
        }
        var teacher = AuthService.CurrentUser as Teacher;

        teacher!.DeleteSubject(SelectedSubject);

        Update();
    }

    public void Update()
    {
        TeacherName = AuthService.CurrentUser!.Name;

        Subjects!.Clear();
        var subjectsIds = AuthService.CurrentUser!.Subjects;

        // Populate the Subjects list from the teacher's subject IDs
        foreach (var subject in DataStoreService.Subjects)
        {
            if (subjectsIds!.Contains(subject.Id))
            {
                Subjects.Add(subject);
            }
        }
    }
}