using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Min<T>(
        in this ArgumentInfo<T> argument, in T minValue, Func<T, T, string>? message = null)
        where T : IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, minValue) >= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, minValue) ?? Messages.Min(argument, minValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Min<T>(
        in this ArgumentInfo<T?> argument, in T minValue, Func<T?, T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, minValue) >= 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value, minValue) ?? Messages.Min(argument, minValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> GreaterThan<T>(
        in this ArgumentInfo<T> argument, in T other, Func<T, T, string>? message = null)
        where T : IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, other) > 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, other) ?? Messages.GreaterThan(argument, other);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> GreaterThan<T>(
        in this ArgumentInfo<T?> argument, in T other, Func<T?, T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, other) > 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value, other) ?? Messages.GreaterThan(argument, other);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Max<T>(
        in this ArgumentInfo<T> argument, in T maxValue, Func<T, T, string>? message = null)
        where T : IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, maxValue) <= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, maxValue) ?? Messages.Max(argument, maxValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Max<T>(
        in this ArgumentInfo<T?> argument, in T maxValue, Func<T?, T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, maxValue) <= 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value, maxValue) ?? Messages.Max(argument, maxValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> LessThan<T>(
        in this ArgumentInfo<T> argument, in T other, Func<T, T, string>? message = null)
        where T : IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, other) < 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, other) ?? Messages.LessThan(argument, other);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> LessThan<T>(
        in this ArgumentInfo<T?> argument, in T other, Func<T?, T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, other) < 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value, other) ?? Messages.LessThan(argument, other);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> InRange<T>(
        in this ArgumentInfo<T> argument, in T minValue, in T maxValue, Func<T, T, T, string>? message = null)
        where T : IComparable<T>
    {
        var comparer = Comparer<T>.Default;
        if (comparer.Compare(argument.Value, minValue) >= 0 && comparer.Compare(argument.Value, maxValue) <= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, minValue, maxValue) ?? Messages.InRange(argument, minValue, maxValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> InRange<T>(
        in this ArgumentInfo<T?> argument, in T minValue, in T maxValue, Func<T?, T, T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var comparer = Comparer<T>.Default;
        var value = argument.Value.Value;
        if (comparer.Compare(value, minValue) >= 0 && comparer.Compare(value, maxValue) <= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, minValue, maxValue) ?? Messages.InRange(argument, minValue, maxValue);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Zero<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) == 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Zero(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Zero<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) == 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.Zero(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotZero<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) != 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotZero(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotZero<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) != 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.NotZero(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Positive<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) > 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Positive(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Positive<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) > 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.Positive(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotPositive<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) <= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositive(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotPositive<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) <= 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.NotPositive(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Negative<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) < 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Negative(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Negative<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) < 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.Negative(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotNegative<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (Comparer<T>.Default.Compare(argument.Value, default) >= 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegative(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : argument.Value, m);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotNegative<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct, IComparable<T>
    {
        if (argument.Value == null || Comparer<T>.Default.Compare(argument.Value.Value, default) >= 0)
        {
            return ref argument;
        }

        var value = argument.Value.Value;
        var m = message?.Invoke(argument.Value) ?? Messages.NotNegative(argument);
        throw new ArgumentOutOfRangeException(argument.Name, argument.Secure ? null : value, m);
    }
}
