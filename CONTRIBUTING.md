# Contributing to ArgDefender

## Bugs, features, and questions

[Report a bug][1] with a reproducible example and the expected behavior.
[Discuss a feature][2] before implementing it so its scope and API can be agreed on.

For usage, see the [README](README.md) and [standard validations](docs/standard-validations.md).
If those do not answer your question, [open a question][3].

## Code contributions

Use the .NET 10 SDK and follow [.editorconfig](.editorconfig).
Include tests for behavior changes and run the test suite before submitting a pull request:

```sh
dotnet test ArgDefender.sln
```

Describe the change and link the related issue in your pull request.

[1]: https://github.com/ftechmax/argdefender/issues/new?template=bug_report.md
[2]: https://github.com/ftechmax/argdefender/issues/new?template=feature_request.md
[3]: https://github.com/ftechmax/argdefender/issues/new?template=question.md
