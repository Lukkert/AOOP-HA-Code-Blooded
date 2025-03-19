using System.Security.Cryptography;
using System.Text;
using ScheduleApp.Interfaces;

namespace ScheduleApp.Models;

public static class AuthService
{
    public static IUser? CurrentUser = null;
    public static IUser? ValidateCredentials(string? username, string? password)
    {
        if (password != null)
            password = HashPassword(password);

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

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}