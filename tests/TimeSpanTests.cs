using Shouldly;

namespace ArgDefender.Test;

public class TimeSpanTests
{
    [Test]
    public void Zero_Pass()
    {
        var arg = TimeSpan.Zero;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        var arg = TimeSpan.FromSeconds(1);

        Action act = () => Guard.Argument(arg).Zero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Nullable_Null_Pass()
    {
        TimeSpan? arg = null;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Pass()
    {
        var arg = TimeSpan.FromMilliseconds(10);

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        var arg = TimeSpan.Zero;

        Action act = () => Guard.Argument(arg).NotZero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        var arg = TimeSpan.FromSeconds(2);

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        var arg = TimeSpan.Zero;

        Action act = () => Guard.Argument(arg).Positive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        var arg = TimeSpan.Zero;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        var arg = TimeSpan.FromSeconds(1);

        Action act = () => Guard.Argument(arg).NotPositive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        var arg = TimeSpan.FromSeconds(-1);

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        var arg = TimeSpan.Zero;

        Action act = () => Guard.Argument(arg).Negative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        var arg = TimeSpan.Zero;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        var arg = TimeSpan.FromSeconds(-1);

        Action act = () => Guard.Argument(arg).NotNegative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





