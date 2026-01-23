using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Type<T>(
        in this ArgumentInfo<T> argument, Type type, Func<T?, Type, string>? message = null)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        var value = argument.Value;
        if (value != null && type.IsInstanceOfType(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value, type) ?? Messages.Type(ToObjectArgument(argument), type);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotType<T>(
        in this ArgumentInfo<T> argument, Type type, Func<T?, Type, string>? message = null)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        var value = argument.Value;
        if (value == null || !type.IsInstanceOfType(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value, type) ?? Messages.NotType(ToObjectArgument(argument), type);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TArgument> Compatible<TArgument, TTarget>(
        in this ArgumentInfo<TArgument> argument, Func<TArgument?, string>? message = null)
    {
        var value = argument.Value;
        if (value != null && typeof(TTarget).IsInstanceOfType(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Compatible<TArgument, TTarget>(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TArgument> NotCompatible<TArgument, TTarget>(
        in this ArgumentInfo<TArgument> argument, Func<TArgument?, string>? message = null)
    {
        var value = argument.Value;
        if (value == null || !typeof(TTarget).IsInstanceOfType(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.NotCompatible<TArgument, TTarget>(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ArgumentInfo<object> ToObjectArgument<T>(in ArgumentInfo<T> argument)
        => new(argument.Value!, modified: argument.Modified, secure: argument.Secure, name: argument.Name);
}
