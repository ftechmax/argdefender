using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Null<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : class
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Null(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Null<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Null(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotNull<T>(
        in this ArgumentInfo<T> argument, Func<T?, string>? message = null)
        where T : class
    {
        if (argument.Value != null)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNull(argument);
        throw new ArgumentNullException(argument.Name, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotNull<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct
    {
        if (argument.Value != null)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNull(argument);
        throw new ArgumentNullException(argument.Name, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotAllNull<T1, T2>(
        in ArgumentInfo<T1> argument1, in ArgumentInfo<T2> argument2, Func<string, string, string>? message = null)
    {
        if (argument1.Value != null || argument2.Value != null)
        {
            return;
        }

        var m = message?.Invoke(argument1.Name, argument2.Name) ?? Messages.NotAllNull(argument1.Name, argument2.Name);
        var paramName = $"{argument1.Name}, {argument2.Name}";
        throw new ArgumentNullException(paramName, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void NotAllNull<T1, T2, T3>(
        in ArgumentInfo<T1> argument1,
        in ArgumentInfo<T2> argument2,
        in ArgumentInfo<T3> argument3,
        Func<string, string, string, string>? message = null)
    {
        if (argument1.Value != null || argument2.Value != null || argument3.Value != null)
        {
            return;
        }

        var m = message?.Invoke(argument1.Name, argument2.Name, argument3.Name) ?? Messages.NotAllNull(argument1.Name, argument2.Name, argument3.Name);
        var paramName = $"{argument1.Name}, {argument2.Name}, {argument3.Name}";
        throw new ArgumentNullException(paramName, m);
    }
}
