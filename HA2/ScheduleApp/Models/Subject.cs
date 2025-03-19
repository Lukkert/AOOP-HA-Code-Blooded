using System.Collections.Generic;
namespace ScheduleApp.Models;

public class Subject(int Id, string Name, string Description, int TeacherId)
{
    public int Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public string Description { get; set; } = Description;
    public int TeacherId { get; set; } = TeacherId;
    public List<Student> StudentsEnrolled { get; set; } = new List<Student>();
}
