using System;
using System.Threading;
using System.Threading.Tasks;
using TurnBase;

public static class ObjectExt
{


    public static async Task ToMySignal(this Godot.Object obj, string signal)
    {
        try
        {
            await obj.ToSignal(obj, signal);
        }
        catch (ObjectDisposedException)
        {
            return;
        }
    }

    public static async Task<T> ToMySignal<T>(this Godot.Object obj, string signal)
    {
        try
        {
            var result = await obj.ToSignal(obj, signal);
            return (T)Convert.ChangeType(result[0], typeof(T));
        }
        catch (ObjectDisposedException)
        {
            return default;
        }
    }

    public static async Task<(T1, T2)> ToMySignal<T1, T2>(this Godot.Object obj, string signal)
    {
        try
        {
            var result = await obj.ToSignal(obj, signal);
            return (
                (T1)Convert.ChangeType(result[0], typeof(T1)),
                (T2)Convert.ChangeType(result[1], typeof(T2))
            );
        }
        catch (ObjectDisposedException)
        {
            return default;
        }
    }

    public static async Task<(T1, T2, T3)> ToMySignal<T1, T2, T3>(this Godot.Object obj, string signal)
    {
        try
        {
            var result = await obj.ToSignal(obj, signal);
            return (
                (T1)Convert.ChangeType(result[0], typeof(T1)),
                (T2)Convert.ChangeType(result[1], typeof(T2)),
                (T3)Convert.ChangeType(result[2], typeof(T3))
            );
        }
        catch (ObjectDisposedException)
        {
            return default;
        }
    }

    public static async Task<(T1, T2, T3, T4)> ToMySignal<T1, T2, T3, T4>(this Godot.Object obj, string signal)
    {
        try
        {
            var result = await obj.ToSignal(obj, signal);
            return (
                (T1)Convert.ChangeType(result[0], typeof(T1)),
                (T2)Convert.ChangeType(result[1], typeof(T2)),
                (T3)Convert.ChangeType(result[2], typeof(T3)),
                (T4)Convert.ChangeType(result[3], typeof(T4))
            );
        }
        catch (ObjectDisposedException)
        {
            return default;
        }
    }
}
