using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Guid> Empty(
        in this ArgumentInfo<Guid> argument, Func<Guid, string>? message = null)
    {
        if (argument.Value == Guid.Empty)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.GuidEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Guid?> Empty(
        in this ArgumentInfo<Guid?> argument, Func<Guid?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value == Guid.Empty)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.GuidEmpty(argument.Value.HasValue ? new ArgumentInfo<Guid>(argument.Value.Value, argument.Modified, argument.Secure, argument.Name) : new ArgumentInfo<Guid>(Guid.Empty, argument.Modified, argument.Secure, argument.Name));
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Guid> NotEmpty(
        in this ArgumentInfo<Guid> argument, Func<Guid, string>? message = null)
    {
        if (argument.Value != Guid.Empty)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.GuidNotEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Guid?> NotEmpty(
        in this ArgumentInfo<Guid?> argument, Func<Guid?, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Value != Guid.Empty)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.GuidNotEmpty(new ArgumentInfo<Guid>(argument.Value.Value, argument.Modified, argument.Secure, argument.Name));
        throw new ArgumentException(m, argument.Name);
    }
}
