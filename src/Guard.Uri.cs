using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriAbsolute(
        in this ArgumentInfo<Uri> argument, Func<Uri, string>? message = null)
    {
        if (argument.Value == null || argument.Value.IsAbsoluteUri)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.UriAbsolute(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriRelative(
        in this ArgumentInfo<Uri> argument, Func<Uri, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.IsAbsoluteUri)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.UriRelative(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriScheme(
        in this ArgumentInfo<Uri> argument, string scheme, Func<Uri, string, string>? message = null)
    {
        if (argument.Value == null || (argument.Value.IsAbsoluteUri && string.Equals(argument.Value.Scheme, scheme, StringComparison.OrdinalIgnoreCase)))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, scheme) ?? Messages.UriScheme(argument, scheme);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriNotScheme(
        in this ArgumentInfo<Uri> argument, string scheme, Func<Uri, string, string>? message = null)
    {
        if (argument.Value == null || !string.Equals(argument.Value.Scheme, scheme, StringComparison.OrdinalIgnoreCase))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, scheme) ?? Messages.UriNotScheme(argument, scheme);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriHttp(
        in this ArgumentInfo<Uri> argument, Func<Uri, string>? message = null)
    {
        if (argument.Value == null || (argument.Value.IsAbsoluteUri && string.Equals(argument.Value.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.UriHttp(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<Uri> UriHttps(
        in this ArgumentInfo<Uri> argument, Func<Uri, string>? message = null)
    {
        if (argument.Value == null || (argument.Value.IsAbsoluteUri && string.Equals(argument.Value.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.UriHttps(argument);
        throw new ArgumentException(m, argument.Name);
    }
}
