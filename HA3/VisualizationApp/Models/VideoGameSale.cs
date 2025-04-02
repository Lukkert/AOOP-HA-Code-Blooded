using CsvHelper.Configuration.Attributes;

namespace VisualizationApp.Models;
class VideoGameSale
{
    [Name("Rank")]
    public int Rank { get; set; }

    [Name("Name")]
    public string Name { get; set; } = string.Empty;

    [Name("Platform")]
    public string Platform { get; set; } = string.Empty;

    [Name("Year")]
    public string Year { get; set; } = string.Empty;

    [Name("Genre")]
    public string Genre { get; set; } = string.Empty;

    [Name("Publisher")]
    public string Publisher { get; set; } = string.Empty;

    [Name("NA_Sales")]
    public double NA_Sales { get; set; }

    [Name("EU_Sales")]
    public double EU_Sales { get; set; }

    [Name("JP_Sales")]
    public double JP_Sales { get; set; }

    [Name("Other_Sales")]
    public double Other_Sales { get; set; }

    [Name("Global_Sales")]
    public double Global_Sales { get; set; }
}