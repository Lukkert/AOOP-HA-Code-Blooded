using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class Users
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Student : User
        {
            public List<int> EnrolledSubjects { get; set; }
        }

        public class Teacher : User
        {
            public List<int> Subjects { get; set; }
        }

    }
}