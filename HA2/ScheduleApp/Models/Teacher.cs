using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class Teacher : User
        {
            public List<Subject>? Subjects { get; set; }
        }
}