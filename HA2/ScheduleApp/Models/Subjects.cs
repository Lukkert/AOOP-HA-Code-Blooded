using System.Collections.Generic;
namespace ScheduleApp.Models
{
    public class Subjects
    {
        public class Subject
        {
            public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            public string Name { get; set; }
            public string Description { get; set; }
            public int TeacherId { get; set; }
            public List<int> StudentsEnrolled { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        }
    }
}