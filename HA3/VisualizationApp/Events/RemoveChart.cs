using System;
using VisualizationApp.ViewModels;

namespace VisualizationApp.Events;

public static class RemoveChart
{
    public static event Action<ChartViewModel>? OnRemoveChart;

    public static void Invoke(ChartViewModel chartViewModel)
    {
        OnRemoveChart?.Invoke(chartViewModel);
    }
}