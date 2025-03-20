using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ScheduleApp.Events;
using ScheduleApp.Models;
using ScheduleApp.Services;

namespace ScheduleApp.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{
    public ObservableCollection<Subject>? Subjects { get; set;} = [];

    [RelayCommand]
    public void Logout()
    {
        ViewSwitch.Invoke("LoginView");
    }

    public void Update()
    {
        //var teacher = AuthService.CurrentUser as Teacher;
        //teacher!.CreateSubject("Math", "#YetAnotherSubjectWithJohn", 1);


        Subjects!.Clear();
        var subjectsIds = AuthService.CurrentUser!.Subjects;

        // Populate the Subjects list from the teacher's subject IDs
        foreach (var subject in DataStoreService.Subjects)
        {
            if (subjectsIds!.Contains(subject.Id))
            {
                Subjects.Add(subject);
                Console.WriteLine("Enrolled subject: " + subject.Name);
            }
        }
    }
}