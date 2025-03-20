using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Interfaces;

public interface IUser
{
    int Id { get; set; }
    string Name { get; set; }
    string Password { get; set; }
    string ProfilePicturePath { get; set;}
    List<Guid>? Subjects { get; set; }

    string ToString();
}
