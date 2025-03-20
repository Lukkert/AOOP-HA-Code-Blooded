using System;

namespace ScheduleApp.Events;

public static class ShowPopup
{
    public static event Action<string>? OnPopup;

    public static void Invoke(string message)
    {
        OnPopup?.Invoke(message);
    }
}