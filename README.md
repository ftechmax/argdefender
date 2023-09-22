# ArgDefender

![Logo](logo-64.png)

ArgDefender is a fluent argument validation library that is intuitive, fast and extensible.

[![NuGet](https://img.shields.io/nuget/v/ArgDefender.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/ArgDefender/)
[![Release](https://github.com/ftechmax/argdefender/actions/workflows/release.yml/badge.svg)](https://github.com/ftechmax/argdefender/actions/workflows/release.yml)
[![codecov](https://codecov.io/gh/ftechmax/argdefender/graph/badge.svg?token=I4QI609IIQ)](https://codecov.io/gh/ftechmax/argdefender)  

```sh
dotnet add package ArgDefender
```

```powershell
Install-Package ArgDefender
```

> [!NOTE]  
> This project is a continuation of the archived Dawn.Guard. The project will go on as ArgDefender. One major upgrade for vNext is the addition of the CallerArgumentExpressionAttribute

- [ArgDefender](#argdefender)
  - [Introduction](#introduction)
  - [What's Wrong with Vanilla?](#whats-wrong-with-vanilla)
  - [Requirements](#requirements)
  - [More](#more)
    - [Standard Validations](#standard-validations)
    - [Design Decisions](#design-decisions)
    - [Extensibility](#extensibility)
    - [Code Snippets](#code-snippets)

## Introduction

Here is a sample constructor that validates its arguments without ArgDefender:

```c#
public Person(string name, int age)
{
    if (name == null)
        throw new ArgumentNullException(nameof(name), "Name cannot be null.");

    if (name.Length == 0)
        throw new ArgumentException("Name cannot be empty.", nameof(name));

    if (age < 0)
        throw new ArgumentOutOfRangeException(nameof(age), age, "Age cannot be less than zero.");

    Name = name;
    Age = age;
}
```

And this is how we write the same constructor with ArgDefender:

```c#
using ArgDefender; // Bring ArgDefender into scope.

public Person(string name, int age)
{
    Name = Guard.Argument(name, nameof(name)).NotNull().NotEmpty();
    Age = Guard.Argument(age, nameof(age)).Min(0);
}
```

If this looks like too much allocations to you, fear not. The arguments are read-only structs that
are passed by reference. See the [design decisions](#design-decisions) for details and an
introduction to ArgDefender's more advanced features.

## What's Wrong with Vanilla?

There is nothing wrong with writing your own checks but when you have lots of types you need to
validate, the task gets very tedious, very quickly.

Let's analyze the string validation in the example without ArgDefender:

* We have an argument (name) that we need to be a non-null, non-empty string.
* We check if it's null and throw an `ArgumentNullException` if it is.
* We then check if it's empty and throw an `ArgumentException` if it is.
* We specify the same parameter name for each validation.
* We write an error message for each validation.
* `ArgumentNullException` accepts the parameter name as its first argument and error message as its
second while it's the other way around for the `ArgumentException`. An inconsistency that many of us
sometimes find it hard to remember.

In reality, all we need to express should be the first bullet, that we want our argument non-null
and non-empty.

With ArgDefender, if you want to guard an argument against null, you just write `NotNull` and that's it.
If the argument is passed null, you'll get an `ArgumentNullException` thrown with the correct
parameter name and a clear error message out of the box. The [standard validations](#standard-validations)
have fully documented, meaningful defaults that get out of your way and let you focus on your project.

## Requirements

**C# 7.2 or later is required.** ArgDefender takes advantage of almost all the new features introduced in
C# 7.2. So in order to use ArgDefender, you need to make sure your Visual Studio is up to date and you
have `<LangVersion>7.2</LangVersion>` or later added in your .csproj file.

**.NET Standard 1.0** and above are supported. [Microsoft Docs][2] lists the following platform
versions as .NET Standard 1.0 compliant but keep in mind that currently, the unit tests are only
targeting .NET Core 3.0.

| Platform                   | Version  |
| -------------------------- | -------- |
| .NET Core                  | `1.0`    |
| .NET Framework             | `4.5`    |
| Mono                       | `4.6`    |
| Xamarin.iOS                | `10.0`   |
| Xamarin.Mac                | `3.0`    |
| Xamarin.Android            | `7.0`    |
| Universal Windows Platform | `10.0`   |
| Windows                    | `8.0`    |
| Windows Phone              | `8.1`    |
| Windows Phone Silverlight  | `8.0`    |
| Unity                      | `2018.1` |

## More

The default branch (dev) is the development branch, so it may contain changes/features that are not
published to NuGet yet. See the [main](https://github.com/ftechmax/argdefender/tree/master) branch for
the latest published version.

### Standard Validations

[Click here][3] for a list of the validations that are included in the library.

### Design Decisions

[Click here][1] for the document that explains the motives behind the ArgDefender's API design and more
advanced features.

### Extensibility

[Click here][4] to see how to add custom validations to ArgDefender by writing simple extension methods.

### Code Snippets

Code snippets can be found in the [snippets][5] folder. Currently, only the Visual Studio is
supported.

[1]: docs/design-decisions.md
[2]: https://docs.microsoft.com/dotnet/standard/net-standard
[3]: docs/standard-validations.md
[4]: docs/extensibility.md
[5]: snippets
