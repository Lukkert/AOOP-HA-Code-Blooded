using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VisualizationApp.Models
{
    public class QueryByName
    {
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
    }
}