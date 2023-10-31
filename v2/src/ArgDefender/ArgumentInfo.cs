using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ArgDefender;

/// <summary>Represents a method argument.</summary>
/// <typeparam name="T">The type of the method argument.</typeparam>
[DebuggerDisplay("{DebuggerDisplay,nq}")]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct ArgumentInfo<T>
{
    /// <summary>The default name for the arguments of type <typeparamref name="T" />.</summary>
    private static readonly string DefaultName = $"The {typeof(T)} argument";

    /// <summary>The argument name.</summary>
    private readonly string? _name;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ArgumentInfo{T} " /> struct.
    /// </summary>
    /// <param name="value">The value of the method argument.</param>
    /// <param name="name">The name of the method argument.</param>
    /// <param name="modified">
    ///     Whether the original method argument is modified before the initialization of
    ///     this instance.
    /// </param>
    /// <param name="secure">
    ///     Pass <c>true</c> for the validation parameters to be excluded from the exception
    ///     messages of failed validations.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ArgumentInfo(
        T? value,
        bool modified = false,
        bool secure = false,
        [CallerArgumentExpression("value")] string? name = null)
    {
        Value = value;
        _name = name;
        Modified = modified;
        Secure = secure;
    }

    /// <summary>Gets the argument value.</summary>
    public T? Value { get; }

    /// <summary>Gets the argument name.</summary>
    public string Name => _name ?? DefaultName;

    /// <summary>
    ///     Gets a value indicating whether the original method argument is modified before
    ///     the initialization of this instance.
    /// </summary>
    public bool Modified { get; }

    /// <summary>
    ///     Gets a value indicating whether sensitive information may be used to validate the
    ///     argument. If <c>true</c>, exception messages provide less information about the
    ///     validation parameters.
    /// </summary>
    public bool Secure { get; }

    /// <summary>Gets how the layout is displayed in the debugger variable windows.</summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal string DebuggerDisplay
    {
        get
        {
            var name = _name;
            var value = Value?.ToString() ?? "null";
            var result = name is null ? value : $"{name}: {value}";
            return Secure ? $"[SECURE] {result}" : result;
        }
    }

    /// <summary>Gets the value of an argument.</summary>
    /// <param name="argument">The argument whose value to return.</param>
    /// <returns><see cref="Value" />.</returns>
    public static implicit operator T(ArgumentInfo<T> argument) => argument.Value;

    /////// <summary>Determines whether the argument value is not <c>null</c>.</summary>
    /////// <returns>
    ///////     <c>true</c>, if <see cref="Value" /> is not <c>null</c>; otherwise, <c>false</c>.
    /////// </returns>
    ////[MethodImpl(MethodImplOptions.AggressiveInlining)]
    ////public bool HasValue() => Value != null;

    /// <summary>Returns the string representation of the argument value.</summary>
    /// <returns>String representation of the argument value.</returns>
    public override string ToString() => Value?.ToString() ?? string.Empty;
}
