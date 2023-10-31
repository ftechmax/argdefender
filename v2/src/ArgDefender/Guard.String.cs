using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    /// <summary>Requires the argument to have an empty string value.</summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and contains one or more characters.
    /// </exception>
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

    /// <summary>Requires the argument to have a non-empty string value.</summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="message">
    ///     The message of the exception that will be thrown if the precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and does not contain any characters.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that consists only of white-space characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and contains one or more
    ///     characters that are not white-space.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that does not consist only of
    ///     white-space characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and contains only of
    ///     white-space characters.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that consists of specified number of characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="length">
    ///     The exact number of characters that the argument value is required to have.
    /// </param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and does not have the exact
    ///     number of characters specified in <paramref name="length" />.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that does not consist of specified
    ///     number of characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="length">
    ///     The exact number of characters that the argument value is required not to have.
    /// </param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and has the exact number of
    ///     characters specified in <paramref name="length" />.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that contains at least the specified
    ///     number of characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="minLength">
    ///     The minimum number of characters allowed in the argument value.
    /// </param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and contains less than the
    ///     specified number of characters.
    /// </exception>
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

    /// <summary>
    ///     Requires the argument to have a string value that contains no more than the specified
    ///     number of characters.
    /// </summary>
    /// <param name="argument">The string argument.</param>
    /// <param name="maxLength">
    ///     The maximum number of characters allowed in the argument value.
    /// </param>
    /// <param name="message">
    ///     The factory to initialize the message of the exception that will be thrown if the
    ///     precondition is not satisfied.
    /// </param>
    /// <returns><paramref name="argument" />.</returns>
    /// <exception cref="ArgumentException">
    ///     <paramref name="argument" /> value is not <c>null</c> and contains more than the
    ///     specified number of characters.
    /// </exception>
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

    /*

       public static string StringLengthInRange(in ArgumentInfo<string> argument, int minLength, int maxLength)
       => $"{argument.Name} must contain {minLength} to {maxLength} characters.";

       public static string StringStartsWith(in ArgumentInfo<string> argument, string value)
       => argument.Secure ? Require(argument) : $"{argument.Name} must start with '{value}'.";

       public static string StringDoesNotStartWith(in ArgumentInfo<string> argument, string value)
       => argument.Secure ? Require(argument) : $"{argument.Name} cannot start with '{value}'.";

       public static string StringEndsWith(in ArgumentInfo<string> argument, string value)
       => argument.Secure ? Require(argument) : $"{argument.Name} must end with '{value}'.";

       public static string StringDoesNotEndWith(in ArgumentInfo<string> argument, string value)
       => argument.Secure ? Require(argument) : $"{argument.Name} cannot end with '{value}'.";

       public static string StringMatches(in ArgumentInfo<string> argument, string pattern)
       => argument.Secure ? Require(argument) : $"No match in {argument.Name} could be found by the regular expression '{pattern}'.";

       public static string StringMatchesTimeout(in ArgumentInfo<string> argument, string pattern, TimeSpan matchTimeout)
       => argument.Secure ? Require(argument) : $"No match in {argument.Name} could be found by the regular expression '{pattern}' in {matchTimeout}";

       public static string StringDoesNotMatch(in ArgumentInfo<string> argument, string pattern)
       => argument.Secure ? Require(argument) : $"A match in {argument.Name} is found by the regular expression '{pattern}'.";

       public static string StringDoesNotMatchTimeout(in ArgumentInfo<string> argument, string pattern, TimeSpan matchTimeout)
       => argument.Secure ? Require(argument) : $"{argument.Name} could not entirely be searched by the regular expression '{pattern}' due to time-out {matchTimeout}";

     */
}
