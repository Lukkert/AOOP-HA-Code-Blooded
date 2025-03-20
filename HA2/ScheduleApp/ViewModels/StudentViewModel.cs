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
    private ObservableCollection<Subject>? AvailableSubjects;

    private ObservableCollection<Subject>? EnrolledSubjects;

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
        ShowPopup.Invoke("Logged out!");
    }

    public void Update()
    {
        //var student = AuthService.CurrentUser as Student;
        //var subjectId = new Guid("eeef5b03-946f-4a74-b6ff-9d7e5c34ae29");
        //student!.EnrollSubject(subjectId);

        //var student = AuthService.CurrentUser as Student;
        //var subjectId = new Guid("eeef5b03-946f-4a74-b6ff-9d7e5c34ae29");
        //student!.DropoutSubject(subjectId);

        AvailableSubjects = new ObservableCollection<Subject>(DataStoreService.Subjects);
        EnrolledSubjects = new ObservableCollection<Subject>();

        var subjects = AuthService.CurrentUser!.Subjects;

        // Remove subjects from AvailableSubjects that the student is already enrolled in
        var filteredAvailableSubjects = AvailableSubjects.Where(aSubject => !subjects!.Contains(aSubject.Id)).ToList();
        AvailableSubjects.Clear();
        foreach (var subject in filteredAvailableSubjects)
        {
            AvailableSubjects.Add(subject);
            Console.WriteLine("Available subject: " + subject.Name);
        }

        // Add enrolled subjects to EnrolledSubjects
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