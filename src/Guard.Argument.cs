using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    /// <summary>Creates a chainable guard for a method argument.</summary>
    /// <typeparam name="T">The type of the method argument.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <param name="secure">
    ///     Excludes validation values from default messages for guards that support redaction.
    ///     Custom message callbacks are responsible for their own redaction.
    /// </param>
    /// <param name="name">The argument name, captured from the caller's expression by default.</param>
    /// <returns>The argument and its validation settings.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentInfo<T> Argument<T>(
        T? value, bool secure = false, [CallerArgumentExpression("value")] string? name = null)
        => new(value, secure: secure, name: name);
}
