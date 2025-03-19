/*

Might not use..

using System;
using ScheduleApp.Interfaces;

namespace ScheduleApp.Events;

public static class UserUpdate
{
    public static event Action<IUser>? OnUserUpdate;

    public static void Invoke(IUser user)
    {
        OnUserUpdate?.Invoke(user);
    }
}

*/