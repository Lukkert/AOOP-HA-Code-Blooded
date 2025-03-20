using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ScheduleApp.Models;

namespace ScheduleApp.Services;

public static class DataStoreService
{

    private const string FilePath = "UserData.json";
    public static List<Student> Students { get; set; } = [];
    public static List<Teacher> Teachers { get; set; } = [];
    public static List<Subject> Subjects { get; set; } = [];



    public static void Save()
    {
        File.WriteAllText(FilePath, JsonSerializer.Serialize(new Data(Teachers, Students, Subjects), new JsonSerializerOptions { WriteIndented = true }));
    }

    public static void Load()
    {
        if (!File.Exists(FilePath))
        {
            Console.WriteLine("No File Path Found!");
        }
        Data data = JsonSerializer.Deserialize<Data>(File.ReadAllText(FilePath))!;

        Students = data.Students;
        Teachers = data.Teachers;
        Subjects = data.Subjects;
    }
}

public class Data(List<Teacher> Teachers, List<Student> Students, List<Subject> Subjects)
{
    public List<Teacher> Teachers { get; set; } = Teachers;
    public List<Student> Students { get; set; } = Students;
    public List<Subject> Subjects { get; set; } = Subjects;
}
