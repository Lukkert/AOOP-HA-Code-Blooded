

using System.Collections.Generic;

namespace ScheduleApp.Models

{
    public class Student : User
    {
            public List<Subject>? EnrolledSubjects { get; set; }
    
    }
}