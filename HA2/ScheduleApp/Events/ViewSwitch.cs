using System;

namespace ScheduleApp.Events;

public static class ViewSwitch
{
    public static event Action<string>? OnViewSwitch;

    public static void Invoke(string viewName)
    {
        OnViewSwitch?.Invoke(viewName);
    }
}