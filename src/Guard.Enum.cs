using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Enum<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null) where T : struct, Enum
    {
        if (System.Enum.IsDefined(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Enum(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Enum<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null || System.Enum.IsDefined(argument.Value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Enum(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> EnumDefined<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null) where T : struct, Enum
    {
        if (System.Enum.IsDefined(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumDefined(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> EnumDefined<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null || System.Enum.IsDefined(argument.Value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumDefined(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> EnumNone<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null) where T : struct, Enum
    {
        if (EqualityComparer<T>.Default.Equals(argument.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumNone(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> EnumNone<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null || EqualityComparer<T>.Default.Equals(argument.Value.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumNone(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> EnumNotNone<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null) where T : struct, Enum
    {
        if (!EqualityComparer<T>.Default.Equals(argument.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumNotNone(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> EnumNotNone<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null || !EqualityComparer<T>.Default.Equals(argument.Value.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EnumNotNone(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> EnumHasFlag<T>(
        in this ArgumentInfo<T> argument, T flag, Func<T, T, string>? message = null) where T : struct, Enum
    {
        if (argument.Value.HasFlag(flag))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, flag) ?? Messages.EnumHasFlag(argument, flag);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> EnumHasFlag<T>(
        in this ArgumentInfo<T?> argument, T flag, Func<T?, T, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null)
        {
            return ref argument;
        }

        if (argument.Value.Value.HasFlag(flag))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, flag) ?? Messages.EnumHasFlag(argument, flag);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> EnumDoesNotHaveFlag<T>(
        in this ArgumentInfo<T> argument, T flag, Func<T, T, string>? message = null) where T : struct, Enum
    {
        if (!argument.Value.HasFlag(flag))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, flag) ?? Messages.EnumDoesNotHaveFlag(argument, flag);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> EnumDoesNotHaveFlag<T>(
        in this ArgumentInfo<T?> argument, T flag, Func<T?, T, string>? message = null) where T : struct, Enum
    {
        if (argument.Value is null)
        {
            return ref argument;
        }

        if (!argument.Value.Value.HasFlag(flag))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, flag) ?? Messages.EnumDoesNotHaveFlag(argument, flag);
        throw new ArgumentException(m, argument.Name);
    }
}
