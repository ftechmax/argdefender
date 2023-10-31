using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    /// <summary>
    ///     Returns an object that can be used to assert preconditions for the method argument
    ///     with the specified name and value.
    /// </summary>
    /// <typeparam name="T">The type of the method argument.</typeparam>
    /// <param name="value">The value of the method argument.</param>
    /// <param name="name">
    ///     <para>
    ///         The name of the method argument. Use the <c>nameof</c> operator ( <c>Nameof</c>
    ///         in Visual Basic) where possible.
    ///     </para>
    ///     <para>
    ///         It is highly recommended you don't left this value <c>null</c> so the arguments
    ///         violating the preconditions can be easily identified.
    ///     </para>
    /// </param>
    /// <param name="secure">
    ///     Pass <c>true</c> for the validation parameters to be excluded from the exception
    ///     messages of failed validations.
    /// </param>
    /// <returns>An object used for asserting preconditions.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ArgumentInfo<T> Argument<T>(
        T? value, bool secure = false, [CallerArgumentExpression("value")] string? name = null)
        => new(value, secure: secure, name: name);
}
