using System.Collections.Generic;
namespace ScheduleApp.Models
{
    public class Subject
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int TeacherId { get; set; }
            public List<Student> StudentsEnrolled { get; set; }= new List<Student>();

            public Subject(int _Id,string _Name,string _Description,int _TeacherId)
            {
                Id = _Id;
                Name = _Name;
                Description = _Description;
                TeacherId = _TeacherId;
            }

    }
}