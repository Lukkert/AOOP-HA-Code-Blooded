using System.Collections.Generic;
namespace ScheduleApp.Models
{
    public class Subjects
    {
        public class Subject
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int TeacherId { get; set; }
            public List<int> StudentsEnrolled { get; set; }
        }
    }
}