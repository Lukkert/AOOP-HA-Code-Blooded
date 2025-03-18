using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace ScheduleApp.Models
{
    public class JsonManager
    {
            public class DataStore
        {
        private const string FilePath = "data.json";
        public List<Users.Student> Students { get; set; } = new();
        public List<Users.Teacher> Teachers { get; set; } = new();
        public List<Subjects.Subject> Subjects { get; set; } = new();

        
        public void Save() => File.WriteAllText(FilePath, JsonSerializer.Serialize(this));
        public static DataStore Load() => File.Exists(FilePath) ? JsonSerializer.Deserialize<DataStore>(File.ReadAllText(FilePath)) : new DataStore();
        }

     // public void Save(string filename, ObservableCollection<Login> data) // From Exercise
     //     {
     //         File.WriteAllText(filename, JsonSerializer.Serialize(data));
     //     }
    }
}