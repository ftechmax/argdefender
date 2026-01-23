using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NaN(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (float.IsNaN(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NaN(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || float.IsNaN(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotNaN(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (!float.IsNaN(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotNaN(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !float.IsNaN(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNaN(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> Infinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (float.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Infinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> Infinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || float.IsInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Infinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotInfinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (!float.IsInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotInfinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !float.IsInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> PositiveInfinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (float.IsPositiveInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.PositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> PositiveInfinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || float.IsPositiveInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.PositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotPositiveInfinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (!float.IsPositiveInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotPositiveInfinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !float.IsPositiveInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotPositiveInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NegativeInfinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (float.IsNegativeInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NegativeInfinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || float.IsNegativeInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotNegativeInfinity(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (!float.IsNegativeInfinity(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotNegativeInfinity(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !float.IsNegativeInfinity(value.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNegativeInfinity(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> Zero(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value == 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> Zero(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value == 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotZero(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value != 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotZero(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value != 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> Positive(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value > 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> Positive(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value > 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotPositive(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value <= 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotPositive(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value <= 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> Negative(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value < 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> Negative(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value < 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotNegative(
        in this ArgumentInfo<float> argument, Func<float, string>? message = null)
    {
        if (argument.Value >= 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotNegative(
        in this ArgumentInfo<float?> argument, Func<float?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value >= 0f)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
