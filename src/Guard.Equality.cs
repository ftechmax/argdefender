using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Default<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct
    {
        if (EqualityComparer<T>.Default.Equals(argument.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Default(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Default<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct
    {
        if (argument.Value == null || EqualityComparer<T>.Default.Equals(argument.Value.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Default(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotDefault<T>(
        in this ArgumentInfo<T> argument, Func<T, string>? message = null)
        where T : struct
    {
        if (!EqualityComparer<T>.Default.Equals(argument.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotDefault(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotDefault<T>(
        in this ArgumentInfo<T?> argument, Func<T?, string>? message = null)
        where T : struct
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        if (!EqualityComparer<T>.Default.Equals(argument.Value.Value, default))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotDefault(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Equal<T>(
        in this ArgumentInfo<T> argument, in T other, Func<T, T, string>? message = null)
    {
        if (EqualityComparer<T>.Default.Equals(argument.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!, other) ?? Messages.Equal(argument, other);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> Equal<T>(
        in this ArgumentInfo<T?> argument, in T other, Func<T?, T, string>? message = null)
        where T : struct
    {
        if (argument.Value == null || EqualityComparer<T>.Default.Equals(argument.Value.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other) ?? Messages.Equal(argument, other);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> Equal(
        in this ArgumentInfo<double> argument, double other, double delta, Func<double, double, double, string>? message = null)
    {
        if (Math.Abs(argument.Value - other) <= delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.Equal(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> Equal(
        in this ArgumentInfo<double?> argument, double other, double delta, Func<double?, double, double, string>? message = null)
    {
        if (argument.Value == null || Math.Abs(argument.Value.Value - other) <= delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.Equal(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> Equal(
        in this ArgumentInfo<float> argument, float other, float delta, Func<float, float, float, string>? message = null)
    {
        if (Math.Abs(argument.Value - other) <= delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.Equal(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> Equal(
        in this ArgumentInfo<float?> argument, float other, float delta, Func<float?, float, float, string>? message = null)
    {
        if (argument.Value == null || Math.Abs(argument.Value.Value - other) <= delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.Equal(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotEqual<T>(
        in this ArgumentInfo<T> argument, in T other, Func<T, string>? message = null)
    {
        if (!EqualityComparer<T>.Default.Equals(argument.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value!) ?? Messages.NotEqual(argument, other);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T?> NotEqual<T>(
        in this ArgumentInfo<T?> argument, in T other, Func<T?, string>? message = null)
        where T : struct
    {
        if (argument.Value == null || !EqualityComparer<T>.Default.Equals(argument.Value.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.NotEqual(argument, other);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double> NotEqual(
        in this ArgumentInfo<double> argument, double other, double delta, Func<double, double, double, string>? message = null)
    {
        if (Math.Abs(argument.Value - other) > delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.NotEqual(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<double?> NotEqual(
        in this ArgumentInfo<double?> argument, double other, double delta, Func<double?, double, double, string>? message = null)
    {
        if (argument.Value == null || Math.Abs(argument.Value.Value - other) > delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.NotEqual(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float> NotEqual(
        in this ArgumentInfo<float> argument, float other, float delta, Func<float, float, float, string>? message = null)
    {
        if (Math.Abs(argument.Value - other) > delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.NotEqual(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<float?> NotEqual(
        in this ArgumentInfo<float?> argument, float other, float delta, Func<float?, float, float, string>? message = null)
    {
        if (argument.Value == null || Math.Abs(argument.Value.Value - other) > delta)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other, delta) ?? Messages.NotEqual(argument, other, delta);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Same<T>(
        in this ArgumentInfo<T> argument, object other, Func<T, object, string>? message = null) where T : class
    {
        if (argument.Value == null || ReferenceEquals(argument.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other) ?? Messages.Same(argument, other);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotSame<T>(
        in this ArgumentInfo<T> argument, object other, Func<T, object, string>? message = null) where T : class
    {
        if (argument.Value == null || !ReferenceEquals(argument.Value, other))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, other) ?? Messages.NotSame(argument, other);
        throw new ArgumentException(m, argument.Name);
    }
}
