using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using LiveChartsCore.Drawing;
using CommunityToolkit.Mvvm.Input;

using VisualizationApp.Models;
using VisualizationApp.Events;

namespace VisualizationApp.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<ChartViewModel> Charts { get; set; } = [];

    private Stack<ChartViewModel> visibleChartStack = new();
    private Stack<ChartViewModel> hiddenChartStack = new();

    private readonly VideoGameSaleQueries videoGameSaleQueries = new();
    public MainWindowViewModel()
    {
        // Subscribe to the RemoveChart event
        Events.RemoveChart.OnRemoveChart += RemoveChart;
    }
    public void RemoveChart(ChartViewModel chart)
    {
        Charts.Remove(chart);
        StackManipulator.RemoveElement(visibleChartStack, chart);
        hiddenChartStack.Push(chart);
    }

    public void CreateChart(ChartViewModel chart)
    {
        Charts.Add(chart);
        visibleChartStack.Push(chart);
    }

    [RelayCommand]
    public void Redo()
    {
        if (hiddenChartStack.Count > 0)
        {
            var chart = hiddenChartStack.Pop();
            Charts.Add(chart);
            visibleChartStack.Push(chart);
        }
    }

    [RelayCommand]
    public void Undo()
    {
        if (visibleChartStack.Count > 0)
        {
            var chart = visibleChartStack.Pop();
            Charts.Remove(chart);
            hiddenChartStack.Push(chart);
        }
    }

    public void RemoteChart(ChartViewModel chart)
    {
        Charts.Remove(chart);
        hiddenChartStack.Push(chart);
        
    }

    [RelayCommand]
    public void GenerateChart1()
    {
        var (names, sales) = videoGameSaleQueries.Top10_Sales_ByRegion("GLOBAL");

        CreateChart(new ChartViewModel("Top 10 Video Games by Global Sales",
            [
            new ColumnSeries<double>
            {
                Values = sales,
                Name = "Global Sales",
            }
            ],
            names, false));
    }

    [RelayCommand]
    public void GenerateChart2()
    {
        var (names, sales) = videoGameSaleQueries.Top10_Sales_ByRegion("EU");

        CreateChart(new ChartViewModel("Top 10 Video Games by EU Sales",
            [
            new ColumnSeries<double>
            {
                Values = sales,
                Name = "EU Sales",
            }
            ],
            names, false));
    }

    [RelayCommand]
    public void GenerateChart3()
    {
        var (names, sales) = videoGameSaleQueries.Top10_Sales_ByRegion("JP");

        CreateChart(new ChartViewModel("Top 10 Video Games by JP Sales",
            [
            new ColumnSeries<double>
            {
                Values = sales,
                Name = "JP Sales",
            }
            ],
            names, false));
    }

    [RelayCommand]
    public void GenerateChart4()
    {
        var (names, sales) = videoGameSaleQueries.Top10_Sales_ByRegion("NA");

        CreateChart(new ChartViewModel("Top 10 Video Games by NA Sales",
            [
            new ColumnSeries<double>
            {
                Values = sales,
                Name = "NA Sales",
            }
            ],
            names, false));
    }

    [RelayCommand]
    public void GenerateChart5()
    {
        var (regions, sales) = videoGameSaleQueries.Top_Sales_ByName("Terraria", "PC");

        CreateChart(new ChartViewModel("Terraria PC sales by country",
            [
            new LineSeries<double>
            {
                Values = sales,
                Name = "Terraria PC Sales",
            }
            ],
            regions, false));
}

    [RelayCommand]
    public void GenerateChart6()
    {
        var (regions, sales) = videoGameSaleQueries.Top_Sales_ByName("Terraria", "PS4");

        CreateChart(new ChartViewModel("Terraria PS4 sales by country",
            [
            new LineSeries<double>
            {
                Values = sales,
                Name = "Terraria PS4 Sales",
            }
            ],
            regions, false));
}

    [RelayCommand]
    public void GenerateChart7()
    {
        var (regions, sales) = videoGameSaleQueries.Top_Sales_ByName("Mario Kart Wii", "Wii");

        CreateChart(new ChartViewModel("Mario Kart Wii sales by country",
            [
            new LineSeries<double>
            {
                Values = sales,
                Name = "Mario Kart Wii Sales",
            }
            ],
            regions, false));
}

[RelayCommand]
    public void GenerateChart8()
    {
        var (platforms, sales) = videoGameSaleQueries.Top_Platform_BySales();

        CreateChart(new ChartViewModel("Top Platforms by Sales",
            [
            new StepLineSeries<double>
            {
                Values = sales,
                Name = "Platform Sales",
            }
            ],
            platforms, false));
}


}