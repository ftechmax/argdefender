# ArgDefender

Fluent argument validation for .NET that keeps guard clauses readable and fast.

[![NuGet](https://img.shields.io/nuget/v/ArgDefender.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/ArgDefender/)
[![Release](https://github.com/ftechmax/argdefender/actions/workflows/release.yml/badge.svg)](https://github.com/ftechmax/argdefender/actions/workflows/release.yml)
[![codecov](https://codecov.io/gh/ftechmax/argdefender/graph/badge.svg?token=I4QI609IIQ)](https://codecov.io/gh/ftechmax/argdefender)

## Why ArgDefender?

Fail fast: validate inputs at your code boundaries so problems surface immediately, with clear exceptions to pinpoint the offending argument.

- Fluent, chainable guards with clear exception types.
- Null-tolerant for nullable inputs; add `NotNull()` when you need to enforce non-null.
- Automatic parameter names; `Guard.Argument(value)` captures the name so you do not need to pass strings via `nameof()`.
- Optional `secure` mode redacts sensitive values from exception messages.

## Installation

```sh
dotnet add package ArgDefender
```

## Supported frameworks

- net10

## Quick start

```csharp
using ArgDefender;

public sealed class Person
{
    public Person(string name, int age, Uri homepage)
    {
        Guard.Argument(name).NotNull().NotWhiteSpace();
        Guard.Argument(age).Min(0).Max(130);
        Guard.Argument(homepage).UriAbsolute();

        Name = name;
        Age = age;
        Homepage = homepage;
    }

    public string Name { get; }
    public int Age { get; }
    public Uri Homepage { get; }
}
```

## Behavior

ArgDefender throws standard exceptions with consistent, predefined messages:

- Most guards throw `ArgumentException` and include the parameter name in the message.
- Range/comparison guards (`Min`, `Max`, `InRange`, etc.) throw `ArgumentOutOfRangeException`.
- Null enforcement (`NotNull`, `NotAllNull`) throws `ArgumentNullException`.

For checks that would otherwise echo values, `secure: true` replaces the message with "`<name> is invalid.`".

## Examples

### Guard chaining

```csharp
Guard.Argument(name).NotNull().NotEmpty().MaxLength(200);
```

### Custom messages

```csharp
Guard.Argument(port).InRange(1, 65535, (value, min, max) => $"Port must be {min}-{max}.");
```

### Nullable inputs

```csharp
string? name = request.Name;
Guard.Argument(name).NotNull().NotWhiteSpace().MaxLength(40);
```

### Secure mode

```csharp
Guard.Argument(apiKey, secure: true).NotNull().NotWhiteSpace().MinLength(32);
```

### URI checks

```csharp
var homepage = new Uri("https://example.com");
var redirectUri = new Uri("/callback", UriKind.Relative);
Guard.Argument(homepage).UriHttps();
Guard.Argument(redirectUri).UriRelative();
```

### Enum checks

```csharp
var status = Status.Pending;
var permissions = Permissions.Read | Permissions.Write;
Guard.Argument(status).EnumDefined();
Guard.Argument(permissions).EnumHasFlag(Permissions.Read);
```

### Defaults and negatives

```csharp
Guard.Argument(command.Number).NotDefault().NotNegative();
```

For the detailed list, see [docs/standard-validations.md](docs/standard-validations.md).
