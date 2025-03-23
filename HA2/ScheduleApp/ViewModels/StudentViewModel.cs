using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;
using ScheduleApp.Models;
using ScheduleApp.Services;
using ScheduleApp.Views;

namespace ScheduleApp.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    public ObservableCollection<Subject>? AvailableSubjects { get; set; } = new ObservableCollection<Subject>();

    public ObservableCollection<Subject>? EnrolledSubjects { get; set; } = new ObservableCollection<Subject>();

    [ObservableProperty]
    private Subject? selectedAvailableSubject;

    [ObservableProperty]
    private Subject? selectedEnrolledSubject;

    [ObservableProperty]
    private string? studentName;

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }

    [RelayCommand]
    public void Enroll()
    {

        if (SelectedAvailableSubject == null)
        {
            Popup.Invoke("No subject selected to enroll.");
            return;
        }


        var student = AuthService.CurrentUser as Student;

        student!.EnrollSubject(SelectedAvailableSubject!.Id);

        EnrolledSubjects!.Add(SelectedAvailableSubject);
        AvailableSubjects!.Remove(SelectedAvailableSubject); // This damned line caused me 2 hours of debugging.. (It sets SelectedSubject to null..) (It was previously  above enroll subject)

        Update();
    }

    [RelayCommand]
    public void Dropout()
    {
        // Ensure the selected subject and collections are not null
        if (SelectedEnrolledSubject == null)
        {
            Popup.Invoke("No subject selected to drop out.");
            return;
        }

        if (AvailableSubjects == null) AvailableSubjects = new ObservableCollection<Subject>();
        if (EnrolledSubjects == null) EnrolledSubjects = new ObservableCollection<Subject>();

        var student = AuthService.CurrentUser as Student;

        student!.DropoutSubject(SelectedEnrolledSubject.Id);

        AvailableSubjects.Add(SelectedEnrolledSubject);
        EnrolledSubjects.Remove(SelectedEnrolledSubject);

        Update();
    }




    public void Update()
    {
        StudentName = AuthService.CurrentUser!.Name;

        var subjects = AuthService.CurrentUser!.Subjects;

        // Remove subjects from AvailableSubjects that the student is already enrolled in
        var filteredAvailableSubjects = DataStoreService.Subjects
            .Where(aSubject => !subjects!.Contains(aSubject.Id))
            .ToList();

        //
        AvailableSubjects!.Clear();
        foreach (var subject in filteredAvailableSubjects)
        {
            AvailableSubjects.Add(subject);
        }

        //
        EnrolledSubjects!.Clear();
        foreach (var subject in DataStoreService.Subjects)
        {
            if (subjects!.Contains(subject.Id))
            {
                EnrolledSubjects.Add(subject);
            }
        }
    }
}