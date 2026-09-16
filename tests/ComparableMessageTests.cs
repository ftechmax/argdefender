using Shouldly;

namespace ArgDefender.Test;

public class ComparableMessageTests
{
    [TestCaseSource(nameof(Guards))]
    public void Failure_Invokes_Message_Once_And_Respects_Secure(
        Action<int?, bool, Func<int?, string>> validate, int invalidValue)
    {
        foreach (var secure in new[] { false, true })
        {
            foreach (var useDefaultMessage in new[] { false, true })
            {
                // Arrange
                var calls = 0;
                string Message(int? value)
                {
                    value.ShouldBe(invalidValue);
                    calls++;
                    return useDefaultMessage ? null! : "Custom validation failure";
                }

                // Act
                var act = () => validate(invalidValue, secure, Message);

                // Assert
                var exception = act.ShouldThrow<ArgumentOutOfRangeException>();

                calls.ShouldBe(1);
                exception.ParamName.ShouldBe("arg");
                exception.ActualValue.ShouldBe(secure ? null : invalidValue);
                exception.Message.ShouldStartWith(useDefaultMessage ? "arg " : "Custom validation failure");
            }
        }
    }

    [TestCaseSource(nameof(NullableGuards))]
    public void Null_Skips_Validation_And_Message(
        Action<int?, bool, Func<int?, string>> validate, int invalidValue)
    {
        // Act
        var act = () => validate(null, false, _ => throw new InvalidOperationException("Message called for null"));

        // Assert
        act.ShouldNotThrow();
    }

    private static IEnumerable<TestCaseData> Guards()
    {
        yield return Case("Zero", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).Zero(value => message(value)));
        yield return Case("NotZero", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotZero(value => message(value)));
        yield return Case("Positive", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).Positive(value => message(value)));
        yield return Case("NotPositive", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotPositive(value => message(value)));
        yield return Case("Negative", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).Negative(value => message(value)));
        yield return Case("NotNegative", -1, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotNegative(value => message(value)));
        yield return Case("Min", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).Min(2, (value, _) => message(value)));
        yield return Case("Max", 3, (arg, secure, message) =>
            Guard.Argument(arg, secure).Max(2, (value, _) => message(value)));
        yield return Case("GreaterThan", 2, (arg, secure, message) =>
            Guard.Argument(arg, secure).GreaterThan(2, (value, _) => message(value)));
        yield return Case("LessThan", 2, (arg, secure, message) =>
            Guard.Argument(arg, secure).LessThan(2, (value, _) => message(value)));
        yield return Case("InRange", 3, (arg, secure, message) =>
            Guard.Argument(arg, secure).InRange(0, 2, (value, _, _) => message(value)));
        foreach (var test in NullableGuards())
            yield return test;
    }

    private static IEnumerable<TestCaseData> NullableGuards()
    {
        yield return NullableCase("Zero_Nullable", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).Zero(message));
        yield return NullableCase("NotZero_Nullable", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotZero(message));
        yield return NullableCase("Positive_Nullable", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).Positive(message));
        yield return NullableCase("NotPositive_Nullable", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotPositive(message));
        yield return NullableCase("Negative_Nullable", 0, (arg, secure, message) =>
            Guard.Argument(arg, secure).Negative(message));
        yield return NullableCase("NotNegative_Nullable", -1, (arg, secure, message) =>
            Guard.Argument(arg, secure).NotNegative(message));
        yield return NullableCase("Min_Nullable", 1, (arg, secure, message) =>
            Guard.Argument(arg, secure).Min(2, (value, _) => message(value)));
        yield return NullableCase("Max_Nullable", 3, (arg, secure, message) =>
            Guard.Argument(arg, secure).Max(2, (value, _) => message(value)));
        yield return NullableCase("GreaterThan_Nullable", 2, (arg, secure, message) =>
            Guard.Argument(arg, secure).GreaterThan(2, (value, _) => message(value)));
        yield return NullableCase("LessThan_Nullable", 2, (arg, secure, message) =>
            Guard.Argument(arg, secure).LessThan(2, (value, _) => message(value)));
        yield return NullableCase("InRange_Nullable", 3, (arg, secure, message) =>
            Guard.Argument(arg, secure).InRange(0, 2, (value, _, _) => message(value)));
    }

    private static TestCaseData Case(
        string name, int invalidValue, Action<int, bool, Func<int?, string>> validate)
        => NullableCase(name, invalidValue, (arg, secure, message) => validate(arg!.Value, secure, message));

    private static TestCaseData NullableCase(
        string name, int invalidValue, Action<int?, bool, Func<int?, string>> validate)
        => new TestCaseData(validate, invalidValue).SetArgDisplayNames(name, invalidValue.ToString());
}
