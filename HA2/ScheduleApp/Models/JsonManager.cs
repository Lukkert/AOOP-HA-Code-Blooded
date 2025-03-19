using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
namespace ScheduleApp.Models
{
    public class JsonManager
    {
        
        private const string FilePath = "UserData.json";
        public List<Student> Students { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        //public List<Subject> Subjects { get; set; } = new();

        

        public void Save() // From Exercise
         {
             File.WriteAllText(FilePath, JsonSerializer.Serialize(Teachers));
             File.WriteAllText(FilePath, JsonSerializer.Serialize(Students));
         }

         public ObservableCollection<User> Load(string filename)
        {
            if (!File.Exists(filename))
            {
                return new ObservableCollection<User>();
            }
            return JsonSerializer.Deserialize<ObservableCollection<User>>(File.ReadAllText(filename))!;
        }


        
    }
}