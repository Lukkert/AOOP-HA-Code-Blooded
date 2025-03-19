using System;

namespace ScheduleApp.Models;

public static class ViewSwitcher
{
    public static event Action<string>? OnViewChange;

    public static void SwitchView(string viewName)
    {
        OnViewChange?.Invoke(viewName);
    }
}