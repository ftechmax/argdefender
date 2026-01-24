# Standard Validations

This document lists the built-in guards included in ArgDefender.

Each guard is an extension method on `ArgumentInfo<T>` and is typically used via
`Guard.Argument(value)`.

### Null Guards

For `ArgumentInfo<T>` where `T : class` and `ArgumentInfo<T?>` where `T : struct`:
* `Null()`
* `NotNull()`

Static:
* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>)`
* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>, ArgumentInfo<T3>)`

### Equality Guards

For `ArgumentInfo<T>`:
* `Equal(T)`
* `NotEqual(T)`

For `ArgumentInfo<T?>` where `T : struct`:
* `Equal(T)`
* `NotEqual(T)`

For `ArgumentInfo<T>` where `T : class`:
* `Same(object)`
* `NotSame(object)`

For `ArgumentInfo<T>` and `ArgumentInfo<T?>` where `T : struct`:
* `Default()`
* `NotDefault()`

### Comparison Guards

For `ArgumentInfo<T>` where `T : IComparable<T>`:
* `Min(T)`
* `Max(T)`
* `GreaterThan(T)`
* `LessThan(T)`
* `InRange(T, T)`
* `Zero()`
* `NotZero()`
* `Positive()`
* `NotPositive()`
* `Negative()`
* `NotNegative()`

For `ArgumentInfo<T?>` where `T : struct, IComparable<T>`:
* `Min(T)`
* `Max(T)`
* `GreaterThan(T)`
* `LessThan(T)`
* `InRange(T, T)`
* `Zero()`
* `NotZero()`
* `Positive()`
* `NotPositive()`
* `Negative()`
* `NotNegative()`

### Boolean Guards

For `ArgumentInfo<bool>` and `ArgumentInfo<bool?>`:
* `True()`
* `False()`

### Collection Guards

For `ArgumentInfo<TCollection>` where `TCollection : IEnumerable`:
* `Empty()`
* `NotEmpty()`
* `Count(int)`
* `NotCount(int)`
* `MinCount(int)`
* `MaxCount(int)`
* `CountInRange(int, int)`
* `Contains(object)`
* `DoesNotContain(object)`

For `ArgumentInfo<TCollection>` where `TCollection : IEnumerable<TItem>`:
* `Contains(TItem)`
* `DoesNotContain(TItem)`
* `Any(Func<TItem, bool>)`
* `All(Func<TItem, bool>)`
* `None(Func<TItem, bool>)`
* `NoDuplicates()`
* `NoDuplicates(IEqualityComparer<TItem>)`

For `ArgumentInfo<TCollection>` where `TCollection : IEnumerable<TItem?>`:
* `AllNotNull()`

For `ArgumentInfo<T>`:
* `In(IEnumerable)`
* `NotIn(IEnumerable)`

### String Guards

For `ArgumentInfo<string>`:
* `Empty()`
* `NotEmpty()`
* `WhiteSpace()`
* `NotWhiteSpace()`
* `Length(int)`
* `NotLength(int)`
* `MinLength(int)`
* `MaxLength(int)`
* `LengthInRange(int, int)`
* `StartsWith(string)`
* `DoesNotStartWith(string)`
* `EndsWith(string)`
* `DoesNotEndWith(string)`
* `Contains(string)`
* `DoesNotContain(string)`
* `StartsWith(string, StringComparison)`
* `DoesNotStartWith(string, StringComparison)`
* `EndsWith(string, StringComparison)`
* `DoesNotEndWith(string, StringComparison)`
* `Contains(string, StringComparison)`
* `DoesNotContain(string, StringComparison)`
* `Matches(string)`
* `MatchesTimeout(string, TimeSpan)`
* `DoesNotMatch(string)`
* `DoesNotMatchTimeout(string, TimeSpan)`

### Guid Guards

For `ArgumentInfo<Guid>` and `ArgumentInfo<Guid?>`:
* `Empty()`
* `NotEmpty()`

### Enum Guards

For `ArgumentInfo<T>` and `ArgumentInfo<T?>` where `T : struct, Enum`:
* `Enum()`
* `EnumDefined()`
* `EnumNone()`
* `EnumNotNone()`
* `EnumHasFlag(T)`
* `EnumDoesNotHaveFlag(T)`

### Floating-Point Guards

For `ArgumentInfo<float>` and `ArgumentInfo<float?>`:
* `NaN()`
* `NotNaN()`
* `Infinity()`
* `NotInfinity()`
* `Finite()`
* `NotFinite()`
* `PositiveInfinity()`
* `NotPositiveInfinity()`
* `NegativeInfinity()`
* `NotNegativeInfinity()`
* `Equal(float, float)` - Approx equality.
* `NotEqual(float, float)` - Approx inequality.

For `ArgumentInfo<double>` and `ArgumentInfo<double?>`:
* `NaN()`
* `NotNaN()`
* `Infinity()`
* `NotInfinity()`
* `Finite()`
* `NotFinite()`
* `PositiveInfinity()`
* `NotPositiveInfinity()`
* `NegativeInfinity()`
* `NotNegativeInfinity()`
* `Equal(double, double)` - Approx equality.
* `NotEqual(double, double)` - Approx inequality.

### Time Guards

For `ArgumentInfo<DateTime>` and `ArgumentInfo<DateTime?>`:
* `KindSpecified()`
* `KindUnspecified()`

For `ArgumentInfo<DateTimeOffset>` and `ArgumentInfo<DateTimeOffset?>`:
* `KindSpecified()`
* `KindUnspecified()`

### TimeSpan Guards

For `ArgumentInfo<TimeSpan>` and `ArgumentInfo<TimeSpan?>`:
* `Zero()`
* `NotZero()`
* `Positive()`
* `NotPositive()`
* `Negative()`
* `NotNegative()`

### URI Guards

For `ArgumentInfo<Uri>`:
* `UriAbsolute()`
* `UriRelative()`
* `UriScheme(string)`
* `UriNotScheme(string)`
* `UriHttp()`
* `UriHttps()`
* `UriHttpOrHttps()`
* `UriHasHost()`
* `UriPortInRange(int, int)`

### Email Guards

For `ArgumentInfo<MailAddress>`:
* `EmailHasHost(string)`
* `EmailDoesNotHaveHost(string)`
* `EmailHostIn(IEnumerable<string>)`
* `EmailHostNotIn(IEnumerable<string>)`
* `EmailHasDisplayName()`
* `EmailDoesNotHaveDisplayName()`

### Type Guards

For `ArgumentInfo<T>`:
* `Type(Type)`
* `NotType(Type)`
* `Compatible<TArgument, TTarget>()`
* `NotCompatible<TArgument, TTarget>()`

### Predicate Guards

For `ArgumentInfo<T>`
* `Require(bool)`
* `Require(Func<T, bool>)`
