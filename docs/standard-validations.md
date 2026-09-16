# Standard Validations

Use extension guards through `Guard.Argument(value)`. `Guard.NotAllNull` is a static method.
Optional custom-message parameters are omitted below.

[Null handling](#null-handling) · [Null](#null-guards) · [Equality](#equality-guards) · [Comparison](#comparison-guards) · [Boolean](#boolean-guards) · [Collections](#collection-guards) · [Strings](#string-guards) · [Guid](#guid-guards) · [Enums](#enum-guards) · [Floating-point](#floating-point-guards) · [Time](#time-guards) · [TimeSpan](#timespan-guards) · [URI](#uri-guards) · [Email](#email-guards) · [Types](#type-guards) · [Predicates](#predicate-guards)

## Null handling

Most guards skip validation when the guarded value is null. Add `NotNull()` first when a value is required. Exceptions include reference-type [equality](#equality-guards) and [comparison](#comparison-guards), positive [type checks](#type-guards), and [predicates](#predicate-guards); their behavior is described below. Required guard parameters, such as predicates, must still be valid even when the guarded value is null.

## Null Guards

For `ArgumentInfo<T>` where `T : class` and `ArgumentInfo<T?>` where `T : struct`:

* `Null()`
* `NotNull()`

Static:

* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>)`
* `NotAllNull(ArgumentInfo<T1>, ArgumentInfo<T2>, ArgumentInfo<T3>)`

At least one argument must be non-null:

```csharp
using ArgDefender;

string? email = null;
string? phone = "555-0100";
Guard.NotAllNull(Guard.Argument(email), Guard.Argument(phone));
```

## Equality Guards

The nullable-struct overloads skip null values. For reference types, `Equal` and `NotEqual` use `EqualityComparer<T>.Default`, including for null: a null string fails `Equal("text")` and passes `Equal(null)`. `Same` and `NotSame` skip null values.

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

## Comparison Guards

`Min`, `Max`, and `InRange` include their boundaries; `GreaterThan` and `LessThan` exclude equality. Length, collection-count, and URI-port ranges also include both boundaries.

Nullable-struct overloads skip null values. Reference-type comparisons use `Comparer<T>.Default` without skipping null, so acceptance depends on the comparison and its bound; for example, a null string fails `Min("a")`.

For `ArgumentInfo<T>` where `T : IComparable<T>`:

* `Min(T)`
* `Max(T)`
* `GreaterThan(T)`
* `LessThan(T)`
* `InRange(T, T)`

The following guards also require `T : struct`:

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

## Boolean Guards

For `ArgumentInfo<bool>` and `ArgumentInfo<bool?>`:

* `True()`
* `False()`

## Collection Guards

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
* `AllNotNull()`
* `NoDuplicates()`

For `ArgumentInfo<TCollection>` where `TCollection : IEnumerable<TItem>`:

* `Contains(TItem)`
* `DoesNotContain(TItem)`
* `Any(Func<TItem, bool>)`
* `All(Func<TItem, bool>)`
* `None(Func<TItem, bool>)`
* `NoDuplicates(IEqualityComparer<TItem>)`

For `ArgumentInfo<T>`:

* `In(IEnumerable)`
* `NotIn(IEnumerable)`

For an empty collection, `All` and `None` pass and `Any` fails. All three skip null collections, but still require a non-null predicate. Explicit lambda parameter types let the compiler infer the item type:

```csharp
using ArgDefender;

var numbers = new List<int> { 1, 2, 3 };
Guard.Argument(numbers)
    .Any((int number) => number > 2)
    .All((int number) => number > 0)
    .None((int number) => number < 0);
```

## String Guards

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

## Guid Guards

For `ArgumentInfo<Guid>` and `ArgumentInfo<Guid?>`:

* `Empty()`
* `NotEmpty()`

## Enum Guards

`Enum()` and `EnumDefined()` both require a declared enum value. A flags combination passes only if that combined value is itself declared; use `EnumHasFlag` to check for particular flags.

For `ArgumentInfo<T>` and `ArgumentInfo<T?>` where `T : struct, Enum`:

* `Enum()`
* `EnumDefined()`
* `EnumNone()`
* `EnumNotNone()`
* `EnumHasFlag(T)`
* `EnumDoesNotHaveFlag(T)`

## Floating-Point Guards

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
* `Equal(float other, float delta)` - Equality within the specified tolerance.
* `NotEqual(float other, float delta)` - Inequality beyond the specified tolerance.

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
* `Equal(double other, double delta)` - Equality within the specified tolerance.
* `NotEqual(double other, double delta)` - Inequality beyond the specified tolerance.

## Time Guards

For `ArgumentInfo<DateTime>` and `ArgumentInfo<DateTime?>`:

* `KindSpecified()`
* `KindUnspecified()`

## TimeSpan Guards

For `ArgumentInfo<TimeSpan>` and `ArgumentInfo<TimeSpan?>`:

* `Zero()`
* `NotZero()`
* `Positive()`
* `NotPositive()`
* `Negative()`
* `NotNegative()`

## URI Guards

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

## Email Guards

For `ArgumentInfo<MailAddress>`:

* `EmailHasHost(string)`
* `EmailDoesNotHaveHost(string)`
* `EmailHostIn(IEnumerable<string>)`
* `EmailHostNotIn(IEnumerable<string>)`
* `EmailHasDisplayName()`
* `EmailDoesNotHaveDisplayName()`

## Type Guards

`Type(Type)` accepts instances of the supplied type, including derived classes and interface implementations. Both `Type` and `Compatible` reject null values; `NotType` and `NotCompatible` accept them.

Supply both type arguments when calling `Compatible`: the guarded argument's type and the target type.

```csharp
using ArgDefender;

object text = "hello";
Guard.Argument(text).Compatible<object, string>();
```

For `ArgumentInfo<T>`:

* `Type(Type)`
* `NotType(Type)`
* `Compatible<TArgument, TTarget>()`
* `NotCompatible<TArgument, TTarget>()`

## Predicate Guards

For `ArgumentInfo<T>`:

* `Require(bool)`
* `Require(Func<T?, bool>)`

`Require` does not skip null values: the predicate receives the guarded value, including null. Use a null-aware condition such as `value => value is not null && value.Length > 0`, or call `NotNull()` first. Chaining `NotNull()` enforces a runtime check but does not change compiler nullable-flow analysis; a subsequent predicate may still need `value!` to express that guarantee. The boolean overload checks the supplied condition regardless of the guarded value.
