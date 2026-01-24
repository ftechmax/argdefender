using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Require<T>(
        in this ArgumentInfo<T> argument,
        bool condition,
        Func<T?, string>? message = null)
    {
        if (condition)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.Require(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> Require<T>(
        in this ArgumentInfo<T> argument,
        Func<T?, bool> predicate,
        Func<T?, string>? message = null)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        var value = argument.Value;
        if (predicate(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.Require(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
