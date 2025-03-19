using System.Collections.Generic;
using ScheduleApp.Interfaces;

namespace ScheduleApp.Models;

public class Student(string Name, string Password) : IUser
{
    private static int _lastId = 1;
    public int Id { get; set; } = _lastId++;
    public string Name { get; set; } = Name;
    public string Password { get; set; } = Password;

    public List<Subject>? EnrolledSubjects { get; set; } = [];

    // Factory method for creating new students (with hashing)
    // You need this, because you don't want to rehash the password again when loading data.
    public static Student Create(string name, string password)
    {
        return new Student(name, AuthService.HashPassword(password));
    }
    public override string ToString()
    {
        return $"Name: {Name}, Role: Student";
    }
}
