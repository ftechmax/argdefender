using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ArgDefender;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
[StructLayout(LayoutKind.Auto)]
public readonly partial struct ArgumentInfo<T>
{
    private static readonly string DefaultName = $"The {typeof(T)} argument";

    private readonly string? _name;

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

    public T? Value { get; }

    public string Name => _name ?? DefaultName;

    public bool Modified { get; }

    public bool Secure { get; }

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

    public static implicit operator T(ArgumentInfo<T> argument) => argument.Value!;

    public override string ToString() => Value?.ToString() ?? string.Empty;
}
