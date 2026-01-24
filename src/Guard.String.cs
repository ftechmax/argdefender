using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ArgDefender;

public static partial class Guard
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> Empty(
        in this ArgumentInfo<string> argument, Func<string, string>? message = null)
    {
        if (!(argument.Value?.Length > 0))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.StringEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> NotEmpty(
        in this ArgumentInfo<string> argument, Func<string, string>? message = null)
    {
        if (argument.Value?.Length != 0)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.StringNotEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> WhiteSpace(
        in this ArgumentInfo<string> argument, Func<string, string>? message = null)
    {
        if (argument.Value == null || string.IsNullOrWhiteSpace(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.StringWhiteSpace(argument);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> NotWhiteSpace(
        in this ArgumentInfo<string> argument, Func<string, string>? message = null)
    {
        if (argument.Value == null || !string.IsNullOrWhiteSpace(argument.Value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value) ?? Messages.StringNotWhiteSpace(argument);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> Length(
        in this ArgumentInfo<string> argument, int length, Func<string, int, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Length == length)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, length) ?? Messages.StringLength(argument, length);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> NotLength(
        in this ArgumentInfo<string> argument, int length, Func<string, int, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Length != length)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, length) ?? Messages.StringNotLength(argument, length);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> MinLength(
        in this ArgumentInfo<string> argument, int minLength, Func<string, int, string>? message = null)
    {
        if (!(argument.Value?.Length < minLength))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, minLength) ?? Messages.StringMinLength(argument, minLength);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> MaxLength(
        in this ArgumentInfo<string> argument, int maxLength, Func<string, int, string>? message = null)
    {
        if (!(argument.Value?.Length > maxLength))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, maxLength) ?? Messages.StringMaxLength(argument, maxLength);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> LengthInRange(
        in this ArgumentInfo<string> argument, int minLength, int maxLength, Func<string, int, int, string>? message = null)
    {
        if (argument.Value == null)
        {
            return ref argument;
        }

        var length = argument.Value.Length;
        if (length >= minLength && length <= maxLength)
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, minLength, maxLength) ?? Messages.StringLengthInRange(argument, minLength, maxLength);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> StartsWith(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || argument.Value.StartsWith(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringStartsWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> StartsWith(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || argument.Value.StartsWith(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringStartsWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotStartWith(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.StartsWith(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringDoesNotStartWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotStartWith(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.StartsWith(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringDoesNotStartWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> EndsWith(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || argument.Value.EndsWith(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringEndsWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> EndsWith(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || argument.Value.EndsWith(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringEndsWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotEndWith(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.EndsWith(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringDoesNotEndWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotEndWith(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.EndsWith(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringDoesNotEndWith(argument, value);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> Contains(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Contains(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringContains(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> Contains(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || argument.Value.Contains(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringContains(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotContain(
        in this ArgumentInfo<string> argument, string value, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.Contains(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value) ?? Messages.StringDoesNotContain(argument, value);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotContain(
        in this ArgumentInfo<string> argument,
        string value,
        StringComparison comparisonType,
        Func<string, string, StringComparison, string>? message = null)
    {
        if (argument.Value == null || !argument.Value.Contains(value, comparisonType))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, value, comparisonType) ?? Messages.StringDoesNotContain(argument, value);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> Matches(
        in this ArgumentInfo<string> argument, string pattern, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || Regex.IsMatch(argument.Value, pattern))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, pattern) ?? Messages.StringMatches(argument, pattern);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> MatchesTimeout(
        in this ArgumentInfo<string> argument, string pattern, TimeSpan matchTimeout, Func<string, string, TimeSpan, string>? message = null)
    {
        if (argument.Value == null || Regex.IsMatch(argument.Value, pattern, RegexOptions.None, matchTimeout))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, pattern, matchTimeout) ?? Messages.StringMatchesTimeout(argument, pattern, matchTimeout);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotMatch(
        in this ArgumentInfo<string> argument, string pattern, Func<string, string, string>? message = null)
    {
        if (argument.Value == null || !Regex.IsMatch(argument.Value, pattern))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, pattern) ?? Messages.StringDoesNotMatch(argument, pattern);
        throw new ArgumentException(m, argument.Name);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<string> DoesNotMatchTimeout(
        in this ArgumentInfo<string> argument, string pattern, TimeSpan matchTimeout, Func<string, string, TimeSpan, string>? message = null)
    {
        if (argument.Value == null || !Regex.IsMatch(argument.Value, pattern, RegexOptions.None, matchTimeout))
        {
            return ref argument;
        }

        var m = message?.Invoke(argument.Value, pattern, matchTimeout) ?? Messages.StringDoesNotMatchTimeout(argument, pattern, matchTimeout);
        throw new ArgumentException(m, argument.Name);
    }

}
