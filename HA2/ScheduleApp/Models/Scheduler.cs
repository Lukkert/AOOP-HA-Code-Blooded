using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia;
//using ReactiveUI;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ScheduleApp.Models
{
    public class Scheduler
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Student : User
        {
            public List<int> EnrolledSubjects { get; set; }
        }

        public class Teacher : User
        {
            public List<int> Subjects { get; set; }
        }

        public class Subject
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int TeacherId { get; set; }
            public List<int> StudentsEnrolled { get; set; }
        }

        public class DataStore
    {
        private const string FilePath = "data.json";
        public List<Student> Students { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        public List<Subject> Subjects { get; set; } = new();

        //public void Save() => File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        //public static DataStore Load() => File.Exists(FilePath) ? JsonConvert.DeserializeObject<DataStore>(File.ReadAllText(FilePath)) ?? new DataStore() : new DataStore();
    }

     // public void Save(string filename, ObservableCollection<Login> data) // From Exercise
     //     {
     //         File.WriteAllText(filename, JsonSerializer.Serialize(data));
     //     }
    }
}