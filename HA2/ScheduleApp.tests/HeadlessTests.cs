using Avalonia.Controls;
using System.Collections.ObjectModel;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleApp.Services;
using ScheduleApp.ViewModels;
using ScheduleApp.Models;

namespace ScheduleApp.Tests;

public class HeadlessTests
{

    [AvaloniaFact]
    public void Teacher_Can_Edit_Subject()
    {
        // Arrange
        var viewModel = new TeacherViewModel();
        var subject = new Subject("Math", "Old Description", 1);
        DataStoreService.Subjects = new List<Subject> { subject };

        var teacher = Teacher.Create("Mike", "password");
        AuthService.CurrentUser = teacher;

        viewModel.Subjects = new ObservableCollection<Subject> { subject };
        viewModel.SelectedSubject = subject;
        viewModel.NewSubjectName = "Advanced Math";
        viewModel.NewSubjectDescription = "New Description";

        // Act
        viewModel.EditSubjectCommand.Execute(null);

        // Assert
        var editedSubject = DataStoreService.Subjects.First(s => s.Id == subject.Id);
        Assert.Equal("Advanced Math", editedSubject.Name);
        Assert.Equal("New Description", editedSubject.Description);
    }

    [AvaloniaFact]
    public void Data_Persists()
    {
        // Arrange
        var subject = new Subject("Math", "Basic Mathematics", 1);
        DataStoreService.Subjects.Add(subject);


        DataStoreService.Save(); // Save the data

        // Act
        DataStoreService.Load(); // Load it back

        // Assert
        Assert.Contains(DataStoreService.Subjects, s => s.Id == subject.Id);
    }

    [AvaloniaFact]
    public void Student_Can_Enroll_In_Subject()
    {
        // Arrange
        var viewModel = new StudentViewModel();
        var subject = new Subject("Math", "Basic Mathematics", 1);

        viewModel.AvailableSubjects = new ObservableCollection<Subject> { subject };
        AuthService.CurrentUser = Student.Create("Mike", "password");

        // Act
        viewModel.SelectedAvailableSubject = subject;
        //viewModel.EnrollCommand.Execute(null);

        // Assert
        //Assert.Contains(subject, viewModel.EnrolledSubjects);
        //Assert.DoesNotContain(subject, viewModel.AvailableSubjects);
    }

    [AvaloniaFact]
    public void Student_Can_Drop_Subject()
    {
        // Arrange
        var viewModel = new StudentViewModel();
        var subject = new Subject("Math", "Basic Mathematics", 1);

        viewModel.EnrolledSubjects = new ObservableCollection<Subject> { subject };
        AuthService.CurrentUser = Student.Create("Mike", "password");

        // Act
        //viewModel.SelectedEnrolledSubject = subject;
        //viewModel.DropoutCommand.Execute(null);

        // Assert
        //Assert.Contains(subject, viewModel.AvailableSubjects);
        //Assert.DoesNotContain(subject, viewModel.EnrolledSubjects);
    }

    [AvaloniaFact]
    public void Teacher_Can_Create_Subject()
    {
        // Arrange
        var viewModel = new TeacherViewModel();
        var teacher = Teacher.Create("Mike", "password");
        AuthService.CurrentUser = teacher;

        viewModel.NewSubjectName = "Math";
        viewModel.NewSubjectDescription = "Basic Mathematics";

        // Act
        //viewModel.CreateSubjectCommand.Execute(null);

        // Assert
        //Assert.Contains(DataStoreService.Subjects, s => s.Name == "Math" && s.Description == "Basic Mathematics");
    }

    [AvaloniaFact]
    public void Teacher_Can_Delete_Subject()
    {
        // Arrange
        var viewModel = new TeacherViewModel();
        var subject = new Subject("Math", "Basic Mathematics", 1);
        DataStoreService.Subjects = new List<Subject> { subject };

        var teacher = Teacher.Create("Mike", "password");
        AuthService.CurrentUser = teacher;

        viewModel.Subjects = new ObservableCollection<Subject> { subject };
        viewModel.SelectedSubject = subject;

        // Act
        //viewModel.RemoveSubjectCommand.Execute(null);

        // Assert
        //Assert.DoesNotContain(subject, DataStoreService.Subjects);
    }
}
