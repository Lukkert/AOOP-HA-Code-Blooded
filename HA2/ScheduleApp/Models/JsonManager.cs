using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
namespace ScheduleApp.Models
{
    public static class JsonManager
    {

        private const string FilePath = "UserData.json";
        public static List<Student> Students { get; set; } = new();
        public static List<Teacher> Teachers { get; set; } = new();
        public static List<Subject> Subjects { get; set; } = new();



        public static void Save()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(new DataStore(Teachers, Students, Subjects), new JsonSerializerOptions { WriteIndented = true }));
        }

        public static ObservableCollection<User> Load(string filename)
        {
            if (!File.Exists(filename))
            {
                return new ObservableCollection<User>();
            }
            return JsonSerializer.Deserialize<ObservableCollection<User>>(File.ReadAllText(filename))!;
        }



    }

    public class DataStore(List<Teacher> teacher, List<Student> students, List<Subject> subjects)
    {
        public List<Teacher> Teachers { get; set; } = teacher;
        public List<Student> Students { get; set; } = students;
        public List<Subject> Subjects { get; set; } = subjects;
    }
}