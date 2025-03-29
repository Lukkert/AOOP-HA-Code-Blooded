using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace VisualizationApp.ViewModels;

public partial class ChartViewModel: ViewModelBase
{
    public string Title { get; set; }
    public ISeries[] Series { get; set; }
    public Axis[] XAxes { get; set; }
    public Axis[] YAxes { get; set; }

    public ChartViewModel(string title, ISeries[] series, bool isRowSeries = false)
    {
        Title = title;
        Series = series;

        if (isRowSeries)
        {
            XAxes = [new Axis { MinLimit = 0 }];
            YAxes = [new Axis { Labels = ["A", "B", "C", "D"] }];
        }
        else
        {
            XAxes = [new Axis { Labels = ["A", "B", "C", "D"] }];
            YAxes = [new Axis { MinLimit = 0 }];
        }
    }
}