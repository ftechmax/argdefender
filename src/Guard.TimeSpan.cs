using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> Zero(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value == TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> Zero(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value == TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Zero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> NotZero(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value != TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> NotZero(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value != TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotZero(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> Positive(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value > TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> Positive(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value > TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Positive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> NotPositive(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value <= TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> NotPositive(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value <= TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotPositive(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> Negative(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value < TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> Negative(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value < TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Negative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan> NotNegative(
        in this ArgumentInfo<TimeSpan> argument, Func<TimeSpan, string>? message = null)
    {
        if (argument.Value >= TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TimeSpan?> NotNegative(
        in this ArgumentInfo<TimeSpan?> argument, Func<TimeSpan?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || value.Value >= TimeSpan.Zero)
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotNegative(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
