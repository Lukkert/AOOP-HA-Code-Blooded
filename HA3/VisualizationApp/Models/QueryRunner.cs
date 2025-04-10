using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VisualizationApp.Models;
public class VideoGameSaleQueries
{
    private readonly List<VideoGameSale> videoGameSalesData;

    public VideoGameSaleQueries()
    {
        // Load the CSV data into the videoGameSalesData list
        CsvLoader<VideoGameSale> videoGameSalesLoader = new();
        videoGameSalesLoader.LoadData("./Assets/VideoGamesSales.csv");
        videoGameSalesData = videoGameSalesLoader.data;
    }

    // Charts 1 - 4;
    public (List<string> Names, List<double> Sales) Top10_Sales_ByRegion(string region)
    {
        List<double> allSales = new();

        // Select the appropriate sales data based on the region
        allSales = region.ToUpper() switch
        {
            "NA" => videoGameSalesData.Select(v => v.NA_Sales).ToList(),
            "EU" => videoGameSalesData.Select(v => v.EU_Sales).ToList(),
            "JP" => videoGameSalesData.Select(v => v.JP_Sales).ToList(),
            "OTHER" => videoGameSalesData.Select(v => v.Other_Sales).ToList(),
            "GLOBAL" => videoGameSalesData.Select(v => v.Global_Sales).ToList(),
            _ => throw new ArgumentException($"Unknown region: {region}"),
        };

        // Combine the sales data with the game names and order by the selected region's sales
        var top10Sales = videoGameSalesData
            .Select((game, index) => new { game.Name, Sale = allSales[index] })  // Pair up the game with its sales
            .OrderByDescending(item => item.Sale)  // Sort by the sales of the region
            .Take(10)
            .ToList();

        var names = top10Sales.Select(item => item.Name).ToList();
        var sales = top10Sales.Select(item => item.Sale).ToList();

        return (names, sales);
    }

    // Chart 5-7 Show the Sales of a game by region
    public (List<string> Regions, List<double> Sales) Top_Sales_ByName(string name, string platform)
    {
        // Find the game by name
        var game = videoGameSalesData.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && v.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase));
        if (game == null)
        {
            throw new ArgumentException($"Game with name '{name}' and platform '{platform}' not found.");
        }

        // Get the sales data for the specified game
        var regions = new List<string> { "Global", "NA", "EU", "JP", "Other" };
        var sales = new List<double>
        {
            game.Global_Sales,
            game.NA_Sales,
            game.EU_Sales,
            game.JP_Sales,
            game.Other_Sales
        };

        return (regions, sales);
    }

    public (List<string> Platforms, List<double> Sales) Top_Platform_BySales()
    {
        // Group the sales data by platform and sum the sales for each platform
        var platformSales = videoGameSalesData
            .GroupBy(v => v.Platform)
            .Select(group => new
            {
                Platform = group.Key,
                TotalSales = group.Sum(v => v.Global_Sales)
            })
            .OrderByDescending(item => item.TotalSales)
            .ToList();

        var platforms = platformSales.Select(item => item.Platform).ToList();
        var sales = platformSales.Select(item => item.TotalSales).ToList();

        return (platforms, sales);
    }
}