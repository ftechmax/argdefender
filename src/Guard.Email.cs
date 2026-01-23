using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailHasHost(
        in this ArgumentInfo<MailAddress> argument, string host, Func<MailAddress, string, string>? message = null)
    {
        if (argument.Value == null || string.Equals(argument.Value.Host, host, StringComparison.OrdinalIgnoreCase))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, host) ?? Messages.EmailHasHost(argument, host);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailDoesNotHaveHost(
        in this ArgumentInfo<MailAddress> argument, string host, Func<MailAddress, string, string>? message = null)
    {
        if (argument.Value == null || !string.Equals(argument.Value.Host, host, StringComparison.OrdinalIgnoreCase))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, host) ?? Messages.EmailDoesNotHaveHost(argument, host);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailHostIn(
        in this ArgumentInfo<MailAddress> argument, IEnumerable<string> hosts, Func<MailAddress, IEnumerable<string>, string>? message = null)
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var hostSet = hosts as ICollection<string> ?? hosts.ToArray();
        var valueHost = argument.Value.Host;
        if (hostSet.Any(h => string.Equals(valueHost, h, StringComparison.OrdinalIgnoreCase)))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, hostSet) ?? Messages.EmailHostIn(argument, hostSet);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailHostNotIn(
        in this ArgumentInfo<MailAddress> argument, IEnumerable<string> hosts, Func<MailAddress, IEnumerable<string>, string>? message = null)
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var hostSet = hosts as ICollection<string> ?? hosts.ToArray();
        var valueHost = argument.Value.Host;
        if (!hostSet.Any(h => string.Equals(valueHost, h, StringComparison.OrdinalIgnoreCase)))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, hostSet) ?? Messages.EmailHostNotIn(argument, hostSet);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailHasDisplayName(
        in this ArgumentInfo<MailAddress> argument, Func<MailAddress, string>? message = null)
    {
        if (argument.Value == null || !string.IsNullOrWhiteSpace(argument.Value.DisplayName))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EmailHasDisplayName(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<MailAddress> EmailDoesNotHaveDisplayName(
        in this ArgumentInfo<MailAddress> argument, Func<MailAddress, string>? message = null)
    {
        if (argument.Value == null || string.IsNullOrWhiteSpace(argument.Value.DisplayName))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.EmailDoesNotHaveDisplayName(argument);
        throw new ArgumentException(m, argument.Name);
    }

}
