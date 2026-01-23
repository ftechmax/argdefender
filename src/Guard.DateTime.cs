using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTime> KindSpecified(
        in this ArgumentInfo<DateTime> argument, Func<DateTime, string>? message = null)
    {
        if (argument.Value.Kind != DateTimeKind.Unspecified)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindSpecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTime?> KindSpecified(
        in this ArgumentInfo<DateTime?> argument, Func<DateTime?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value.Kind != DateTimeKind.Unspecified)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindSpecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTime> KindUnspecified(
        in this ArgumentInfo<DateTime> argument, Func<DateTime, string>? message = null)
    {
        if (argument.Value.Kind == DateTimeKind.Unspecified)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindUnspecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTime?> KindUnspecified(
        in this ArgumentInfo<DateTime?> argument, Func<DateTime?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value.Kind == DateTimeKind.Unspecified)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindUnspecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTimeOffset> KindSpecified(
        in this ArgumentInfo<DateTimeOffset> argument, Func<DateTimeOffset, string>? message = null)
    {
        if (argument.Value.Offset != TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindSpecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTimeOffset?> KindSpecified(
        in this ArgumentInfo<DateTimeOffset?> argument, Func<DateTimeOffset?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value.Offset != TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindSpecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTimeOffset> KindUnspecified(
        in this ArgumentInfo<DateTimeOffset> argument, Func<DateTimeOffset, string>? message = null)
    {
        if (argument.Value.Offset == TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindUnspecified(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<DateTimeOffset?> KindUnspecified(
        in this ArgumentInfo<DateTimeOffset?> argument, Func<DateTimeOffset?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value.Offset == TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.KindUnspecified(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
