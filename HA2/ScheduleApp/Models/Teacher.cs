using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class Teacher(int id, string name, string password) : User(id, name, password)
    {
        public List<Subject>? Subjects { get; set; } = [];
    }
}