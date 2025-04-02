using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;

using VisualizationApp.Events;

namespace VisualizationApp.ViewModels;

public partial class ChartViewModel : ViewModelBase
{
    public string Title { get; set; }
    public ISeries[] Series { get; set; }
    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }

    public ChartViewModel(string title, ISeries[] series, List<string> labels, bool isRowSeries = false)
    {
        Title = title;
        Series = series;

        if (isRowSeries)
        {
            XAxes = [new Axis { MinLimit = 0 }];
            YAxes = [new Axis { Labels = labels }];
        }
        else
        {
            XAxes = [new Axis { Labels = labels }];
            YAxes = [new Axis { MinLimit = 0 }];
        }
    }

    [RelayCommand]
    public void RemoveChart()
    {
        // Invoke the RemoveChart event with this instance
        Events.RemoveChart.Invoke(this);
    }
}