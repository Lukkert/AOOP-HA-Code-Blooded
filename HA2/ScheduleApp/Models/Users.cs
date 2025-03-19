using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class User
    {
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        

        
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    }
}