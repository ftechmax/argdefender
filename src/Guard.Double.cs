using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NaN(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (double.IsNaN(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NaN(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || double.IsNaN(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotNaN(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (!double.IsNaN(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotNaN(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !double.IsNaN(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Infinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (double.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Infinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Infinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || double.IsInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Infinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotInfinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (!double.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotInfinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !double.IsInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Finite(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (!double.IsNaN(argument.Value) && !double.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Finite(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Finite(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || (!double.IsNaN(value.Value) && !double.IsInfinity(value.Value)))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Finite(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotFinite(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (double.IsNaN(argument.Value) || double.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotFinite(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotFinite(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || double.IsNaN(value.Value) || double.IsInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotFinite(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> PositiveInfinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (double.IsPositiveInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.PositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> PositiveInfinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || double.IsPositiveInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.PositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotPositiveInfinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (!double.IsPositiveInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotPositiveInfinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !double.IsPositiveInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotPositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NegativeInfinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (double.IsNegativeInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NegativeInfinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || double.IsNegativeInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotNegativeInfinity(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (!double.IsNegativeInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotNegativeInfinity(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !double.IsNegativeInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Zero(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value == 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Zero(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value == 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotZero(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value != 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotZero(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value != 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Positive(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value > 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Positive(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value > 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotPositive(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value <= 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotPositive(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value <= 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Negative(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value < 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Negative(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value < 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotNegative(
        in this ArgumentInfo<double> argument, Func<double, string>? message = null)
    {
        if (argument.Value >= 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotNegative(
        in this ArgumentInfo<double?> argument, Func<double?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value >= 0d)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
