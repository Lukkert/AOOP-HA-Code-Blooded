using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace VisualizationApp.Models;
public class CsvLoader<T> where T : class
{
    public List<T> data = [];

    public void LoadData(string path)
    {
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            data = csv.GetRecords<T>().ToList();
        }
    }
}