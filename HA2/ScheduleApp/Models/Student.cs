using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleApp.Interfaces;
using ScheduleApp.Services;

namespace ScheduleApp.Models;

public class Student(string Name, string Password, string ProfilePicturePath = "Assets/Default.png") : IUser
{
    private static int _lastId = 1;
    public int Id { get; set; } = _lastId++;
    public string Name { get; set; } = Name;
    public string Password { get; set; } = Password;
    public string ProfilePicturePath { get; set; } = ProfilePicturePath;
    public List<Guid>? Subjects { get; set; } = [];

    // Factory method for creating new students (with hashing)
    // You need this, because you don't want to rehash the password again when loading data.
    public static Student Create(string name, string password, string profilePicturePath = "Assets/Default.png")
    {
        return new Student(name, AuthService.HashPassword(password), profilePicturePath);
    }
    public override string ToString()
    {
        return $"Name: {Name}, Role: Student";
    }

    public void EnrollSubject(Guid subject)
    {
        Subjects!.Add(subject);
        var studentToUpdate = DataStoreService.Students.FirstOrDefault(s => s.Id == Id);
        studentToUpdate!.Subjects = Subjects;

        var subjectToUpdate = DataStoreService.Subjects.FirstOrDefault(s => s.Id == subject);
        subjectToUpdate!.StudentsEnrolled.Add(Id);
    }

    public void DropoutSubject(Guid subject)
    {
        if (Subjects != null)
        {
            Subjects.Remove(subject);  // Remove subject from student's list
        }

        // Find and update the student in the static list, with null check
        var studentToUpdate = DataStoreService.Students.FirstOrDefault(s => s.Id == Id);
        if (studentToUpdate != null)
        {
            studentToUpdate.Subjects = Subjects;
        }
        else
        {
            Console.WriteLine("Student not found for ID: " + Id);
        }

        // Find and update the subject in the static list, with null check
        var subjectToUpdate = DataStoreService.Subjects.FirstOrDefault(s => s.Id == subject);
        if (subjectToUpdate != null)
        {
            subjectToUpdate.StudentsEnrolled.Remove(Id);
        }
        else
        {
            Console.WriteLine("Subject not found for ID: " + subject);
        }
    }

}