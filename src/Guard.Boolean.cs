using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<bool> True(
        in this ArgumentInfo<bool> argument, Func<bool, string>? message = null)
    {
        if (argument.Value)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.True(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<bool?> True(
        in this ArgumentInfo<bool?> argument, Func<bool?, string>? message = null)
    {
        if (argument.Value == true)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.True(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<bool> False(
        in this ArgumentInfo<bool> argument, Func<bool, string>? message = null)
    {
        if (!argument.Value)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.False(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<bool?> False(
        in this ArgumentInfo<bool?> argument, Func<bool?, string>? message = null)
    {
        if (argument.Value == false)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.False(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
