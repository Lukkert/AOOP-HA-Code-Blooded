using ScheduleApp.Interfaces;

namespace ScheduleApp.Models;

public static class AuthService
{
    public static IUser? CurrentUser = null;
    public static IUser? ValidateCredentials(string? username, string? password)
    {
        IUser? User = null;
        foreach (var teacher in DataStoreService.Teachers)
        {
            if (username == teacher.Name && password == teacher.Password)
            {
                User = teacher;
                break;
            }
        }
        foreach (var student in DataStoreService.Students)
        {
            if (username == student.Name && password == student.Password  && User == null)
            {
                User = student;
                break;
            }
        }
        
        CurrentUser = User;
        return User;
    }
}