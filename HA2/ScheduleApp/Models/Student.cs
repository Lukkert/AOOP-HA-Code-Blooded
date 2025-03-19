

using System.Collections.Generic;

namespace ScheduleApp.Models

{
    public class Student(int id, string name, string password) : User(id, name, password)
    {
        public List<Subject>? EnrolledSubjects { get; set;} = [];
    }
}