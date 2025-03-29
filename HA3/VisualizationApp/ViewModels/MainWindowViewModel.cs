using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;

namespace VisualizationApp.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<ChartViewModel> Charts { get; set; } = [];

    public MainWindowViewModel()
    {
        // Test charts
        Charts.Add(new ChartViewModel("Line Chart",
        [
            new LineSeries<double>
            {
                Values = [2, 3, 4, 5]
            }
        ]));

        Charts.Add(new ChartViewModel("Column Chart",
        [
            new ColumnSeries<double>
            {
                Values = [3, 7, 5, 2]
            }
        ]));

        Charts.Add(new ChartViewModel("Stacked Row Chart",
        [
            new StackedRowSeries<double>
            {
                Values = new ObservableCollection<double> { 3, 5, 2, 8 },
                Name = "Series 1",
                StackGroup = 0
            },
            new StackedRowSeries<double>
            {
                Values = new ObservableCollection<double> { 2, 4, 1, 6 },
                Name = "Series 2",
                StackGroup = 0
            }
        ], isRowSeries: true));
    }
}