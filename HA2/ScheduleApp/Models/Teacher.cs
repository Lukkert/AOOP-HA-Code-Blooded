using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleApp.Interfaces;
using ScheduleApp.Services;

namespace ScheduleApp.Models;

public class Teacher(string Name, string Password, string ProfilePicturePath = "Assets/Default.png") : IUser
{
    private static int _lastId = 1;
    public int Id { get; set; } = _lastId++;
    public string Name { get; set; } = Name;
    public string Password { get; set; } = Password;
    public string ProfilePicturePath { get; set; } = ProfilePicturePath;
    public List<Guid>? Subjects { get; set; } = [];

    // Factory method for creating new teachers (with hashing)
    // You need this, because you don't want to rehash the password again when loading data.
    public static Teacher Create(string name, string password, string profilePicturePath = "Assets/Default.png")
    {
        return new Teacher(name, AuthService.HashPassword(password), profilePicturePath);
    }
    public override string ToString()
    {
        return $"Name: {Name}, Role: Teacher";
    }

    public void CreateSubject(string name, string description, int teacherId)
    {
        Subject subject = new Subject(name, description, teacherId);

        Subjects!.Add(subject.Id);
        
        var teacherToUpdate = DataStoreService.Teachers.FirstOrDefault(s => s.Id == Id);
        teacherToUpdate!.Subjects = Subjects;

       DataStoreService.Subjects.Add(subject);

    }

    public void UpdateSubject()
    {
        
    }
    public void DeleteSubject(Subject subject)
    {
        Subjects!.Remove(subject.Id);

        var teacherToUpdate = DataStoreService.Teachers.FirstOrDefault(s => s.Id == Id);
        teacherToUpdate!.Subjects = Subjects;

        DataStoreService.Subjects.Remove(subject);
    }
}
