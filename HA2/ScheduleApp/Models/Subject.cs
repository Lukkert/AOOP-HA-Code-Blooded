using System;
using System.Collections.Generic;
namespace ScheduleApp.Models;

public class Subject(string Name, string Description, int TeacherId)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    public int TeacherId { get; set; } = TeacherId;
    public List<int> StudentsEnrolled { get; set; } = [];
}
