using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class Users
    {
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    }
}