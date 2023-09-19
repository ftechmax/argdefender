# Standard Validations

Below is a complete list of validations that are included with the library. Optional parameters that
allow you to specify custom exception messages are omitted for brevity.

All validations are documented using the XML documentation comments, so IntelliSense works but I haven't
yet decided which tool to use for converting the XML output to HTML. Therefore there is no online
documentation yet.

### Null Guards

For `ArgumentInfo<T> where T : class` and `ArgumentInfo<T?> where T : struct`
* `Null()`
* `NotNull()` - When called for an argument of `T?`, returns an argument of `T`.

Static without type constraints:
* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>)`
* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>, ArgumentInfo<T3>)`

### Equality Guards

For `ArgumentInfo<T>`
* `Equal(T)`
* `Equal(T, IEqualityComparer<T>)`
* `NotEqual(T)`
* `NotEqual(T, IEqualityComparer<T>)`

For `ArgumentInfo<T> where T : class`
* `Same(T)`
* `NotSame(T)`

For `ArgumentInfo<T|T?> where T : struct`
* `Default()`
* `NotDefault()`

### Comparison Guards

For `ArgumentInfo<T> where T : IComparable<T>`
* `Min(T)`
* `Max(T)`
* `GreaterThan(T)`
* `LessThan(T)`
* `InRange(T, T)`

### Boolean Guards

For `ArgumentInfo<bool|bool?>`
* `True()`
* `False()`

### Collection Guards

For `ArgumentInfo<T> where T : IEnumerable`
* `Empty()`
* `NotEmpty()`
* `Count(int)`
* `NotCount(int)`
* `MinCount(int)`
* `MaxCount(int)`
* `CountInRange(int, int)`
* `Contains<TItem>(TItem)`
* `Contains<TItem>(TItem, IEqualityComparer<TItem>)`
* `DoesNotContain<TItem>(TItem)`
* `DoesNotContain<TItem>(TItem, IEqualityComparer<TItem>)`
* `ContainsNull()`
* `DoesNotContainNull()`
* `DoesNotContainDuplicate()`
* `DoesNotContainDuplicate(IEqualityComparer<TItem>)`

For `ArgumentInfo<T>`
* `In<TCollection>(TCollection)`
* `In<TCollection>(TCollection, IEqualityComparer<T>)`
* `NotIn<TCollection>(TCollection)`
* `NotIn<TCollection>(TCollection, IEqualityComparer<T>)`

### String Guards

For `ArgumentInfo<string>`
* `Empty()`
* `NotEmpty()`
* `WhiteSpace()`
* `NotWhiteSpace()`
* `Length(int)`
* `NotLength(int)`
* `MinLength(int)`
* `MaxLength(int)`
* `LengthInRange(int, int)`
* `Equal(string, StringComparison)`
* `NotEqual(string, StringComparison)`
* `StartsWith(string)`
* `StartsWith(string, StringComparison)`
* `DoesNotStartWith(string)`
* `DoesNotStartWith(string, StringComparison)`
* `EndsWith(string)`
* `EndsWith(string, StringComparison)`
* `DoesNotEndWith(string)`
* `DoesNotEndWith(string, StringComparison)`
* `Matches(string)`
* `Matches(string, TimeSpan)`
* `Matches(Regex)`
* `DoesNotMatch(string)`
* `DoesNotMatch(string, TimeSpan)`
* `DoesNotMatch(Regex)`

### Time Guards

For `ArgumentInfo<DateTime|DateTime?>`

* `KindSpecified()`
* `KindUnspecified()`

### Floating-Point Number Guards

For `ArgumentInfo<float|float?|double|double?>`
* `NaN()`
* `NotNaN()`
* `Infinity()`
* `NotInfinity()`
* `PositiveInfinity()`
* `NotPositiveInfinity()`
* `NegativeInfinity()`
* `NotNegativeInfinity()`
* `Equal(T, T)` - Approx. equality.
* `NotEqual(T, T)` - Approx. unequality.

### URI Guards

For `ArgumentInfo<Uri>`
* `Absolute`
* `Relative`
* `Scheme(string)`
* `NotScheme(string)`
* `Http()`
* `Http(bool)`
* `Https()`

### Enum Guards
For `ArgumentInfo<T|T?> where T : struct, Enum`
* `Defined()`
* `HasFlag(T)`
* `DoesNotHaveFlag(T)`

### Email Guards
For `ArgumentInfo<MailAddress>`
* `HasHost(string)`
* `DoesNotHaveHost(string)`
* `HostIn(IEnumerable<string>)`
* `HostNotIn(IEnumerable<string>)`
* `HasDisplayName()`
* `DoesNotHaveDisplayName()`

### Type Guards

For `ArgumentInfo<T>`
* `Compatible<TTarget>()`
* `NotCompatible<TTarget>()`
* `Cast<TTarget>` - Returns an argument of `TTarget`

For `ArgumentInfo<object>`
* `Type<T>()` - Returns an argument of `T`.
* `NotType<T>()`
* `Type(Type)`
* `NotType(Type)`

### Member Guards
For `ArgumentInfo<T>`
* `Member<TMember>(Expression<Func<T, TMember>>, Action<ArgumentInfo<TMember>>)`
* `Member<TMember>(Expression<Func<T, TMember>>, Action<ArgumentInfo<TMember>>, bool)`

### Normalization Guards

For `ArgumentInfo<T>`
* `Modify<TTarget>(TTarget value)` - Returns an argument of `TTarget`
* `Modify<TTarget>(Func<T, TTarget>)` - Returns an argument of `TTarget`
* `Wrap<TTarget>(Func<T, TTarget>)` - Returns an argument of `TTarget`

For `ArgumentInfo<T> where T : class, ICloneable`
* `Clone()`

### Predicate Guards

For `ArgumentInfo<T>`
* `Require(bool)`
* `Require<TException>(bool)`
* `Require(Func<T, bool>)`
* `Require<TException>(Func<T, bool>)`

### State Guards

For validating instance states instead of method arguments:
* `Operation(bool)` - Throws `InvalidOperationException` for `false`
* `Support(bool)` - Throws `NotSupportedException` for `false`
* `Disposal(bool, string)` - Throws `ObjectDisposedException` for `true`
