using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Enum<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null) where T : struct, Enum
    {
        if (global::System.Enum.IsDefined(typeof(T), argument.Value))
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
        if (argument.Value is null || global::System.Enum.IsDefined(typeof(T), argument.Value.Value))
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
        if (global::System.Enum.IsDefined(typeof(T), argument.Value))
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
        if (argument.Value is null || global::System.Enum.IsDefined(typeof(T), argument.Value.Value))
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
        var valueEnum = (global::System.Enum)(object)argument.Value;
        var flagEnum = (global::System.Enum)(object)flag;
        if (valueEnum.HasFlag(flagEnum))
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

        var valueEnum = (global::System.Enum)(object)argument.Value.Value;
        var flagEnum = (global::System.Enum)(object)flag;
        if (valueEnum.HasFlag(flagEnum))
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
        var valueEnum = (global::System.Enum)(object)argument.Value;
        var flagEnum = (global::System.Enum)(object)flag;
        if (!valueEnum.HasFlag(flagEnum))
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

        var valueEnum = (global::System.Enum)(object)argument.Value.Value;
        var flagEnum = (global::System.Enum)(object)flag;
        if (!valueEnum.HasFlag(flagEnum))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, flag) ?? Messages.EnumDoesNotHaveFlag(argument, flag);
        throw new ArgumentException(m, argument.Name);
    }
}
