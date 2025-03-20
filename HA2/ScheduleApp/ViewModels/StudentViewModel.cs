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

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
        ShowPopup.Invoke("Logged out!");
    }

    [RelayCommand]
   public void Enroll()
{
    if (SelectedAvailableSubject != null)
    {
        var student = AuthService.CurrentUser as Student;
        
        if (student != null)
        {
            EnrolledSubjects!.Add(SelectedAvailableSubject);
            AvailableSubjects!.Remove(SelectedAvailableSubject);

            student.EnrollSubject(SelectedAvailableSubject.Id);
            Update();
        }
        else
        {
            // Handle case where student is null
            ShowPopup.Invoke("Student not logged in!");
        }
    }
    else
    {
        ShowPopup.Invoke("No subject selected to enroll!");
    }
}

[RelayCommand]
public void Dropout()
{
    // Ensure the selected subject and collections are not null
    if (SelectedEnrolledSubject == null)
    {
        ShowPopup.Invoke("No subject selected to drop out.");
        return;
    }

    if (AvailableSubjects == null) AvailableSubjects = new ObservableCollection<Subject>();
    if (EnrolledSubjects == null) EnrolledSubjects = new ObservableCollection<Subject>();

    var student = AuthService.CurrentUser as Student;
    if (student == null)
    {
        ShowPopup.Invoke("User is not logged in.");
        return;
    }

    Console.WriteLine($"Attempting to drop out subject: {SelectedEnrolledSubject.Name}");

    // Ensure the subject exists in the enrolled list before attempting to remove
    if (EnrolledSubjects.Contains(SelectedEnrolledSubject))
    {
        AvailableSubjects.Add(SelectedEnrolledSubject);
        EnrolledSubjects.Remove(SelectedEnrolledSubject);
        student.DropoutSubject(SelectedEnrolledSubject.Id);
    }
    else
    {
        ShowPopup.Invoke("Subject not found in enrolled subjects.");
    }

    Update();
}




    public void Update()
    {
        var subjects = AuthService.CurrentUser!.Subjects;

        // Remove subjects from AvailableSubjects that the student is already enrolled in
        var filteredAvailableSubjects = DataStoreService.Subjects
            .Where(aSubject => !subjects!.Contains(aSubject.Id))
            .ToList();

        // Clear the existing AvailableSubjects collection and add the filtered subjects
        AvailableSubjects!.Clear();
        foreach (var subject in filteredAvailableSubjects)
        {
            AvailableSubjects.Add(subject);
            Console.WriteLine("Available subject: " + subject.Name);
        }

        // Clear the existing EnrolledSubjects collection and add the new items
        EnrolledSubjects!.Clear();
        foreach (var subject in DataStoreService.Subjects)
        {
            if (subjects!.Contains(subject.Id))
            {
                EnrolledSubjects.Add(subject);
                Console.WriteLine("Enrolled subject: " + subject.Name);
            }
        }
    }
}