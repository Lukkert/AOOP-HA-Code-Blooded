using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;
using ScheduleApp.Models;
using ScheduleApp.Services;

namespace ScheduleApp.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    [ObservableProperty]
    private List<Subject>? availableSubjects;

    [ObservableProperty]
    private List<Subject>? enrolledSubjects;

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }

    public void Update()
    {
        //var student = AuthService.CurrentUser as Student;
        //var subjectId = new Guid("eeef5b03-946f-4a74-b6ff-9d7e5c34ae29");
        //student!.EnrollSubject(subjectId);

        //var student = AuthService.CurrentUser as Student;
        //var subjectId = new Guid("eeef5b03-946f-4a74-b6ff-9d7e5c34ae29");
        //student!.DropoutSubject(subjectId);


        // Creating and filtering student specific subjects
        AvailableSubjects = [.. DataStoreService.Subjects];
        EnrolledSubjects = new List<Subject>();
        var subjects = AuthService.CurrentUser!.Subjects;
        
        AvailableSubjects.RemoveAll(aSubject => subjects!.Contains(aSubject.Id));

        foreach (var subject in DataStoreService.Subjects)
        {
            if (subjects!.Contains(subject.Id))
            {
                EnrolledSubjects.Add(subject);
                Console.WriteLine("subject");
            }
        }
    }
}