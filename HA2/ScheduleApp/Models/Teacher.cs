using System.Collections.Generic;
using ScheduleApp.Interfaces;

namespace ScheduleApp.Models;

public class Teacher(int Id, string Name, string Password) : IUser
{
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public string Password { get; set; } = Password;

    public List<Subject>? Subjects { get; set; } = [];

    public override string ToString()
    {
        return $"Name: {Name}, Role: Teacher";
    }
}
