using System.Collections.Generic;

namespace ScheduleApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(int _Id, string _Name, string _Password)
        {
            Id = _Id;
            Name = _Name;
            Password = _Password;
            return;
        }

    }
}