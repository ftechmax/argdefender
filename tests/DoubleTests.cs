using Shouldly;

namespace ArgDefender.Test;

public class DoubleTests
{
    [Test]
    public void NaN_Pass()
    {
        var arg = double.NaN;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Fail()
    {
        var arg = 1d;

        Action act = () => Guard.Argument(arg).NaN();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NaN_Nullable_Null_Pass()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Pass()
    {
        var arg = 2d;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Fail()
    {
        var arg = double.NaN;

        Action act = () => Guard.Argument(arg).NotNaN();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Infinity_Pass_Positive()
    {
        var arg = double.PositiveInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Pass_Negative()
    {
        var arg = double.NegativeInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Fail()
    {
        var arg = 10d;

        Action act = () => Guard.Argument(arg).Infinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotInfinity_Pass()
    {
        var arg = 5d;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Fail()
    {
        var arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void PositiveInfinity_Pass()
    {
        var arg = double.PositiveInfinity;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Fail()
    {
        var arg = double.NegativeInfinity;

        Action act = () => Guard.Argument(arg).PositiveInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositiveInfinity_Pass()
    {
        var arg = 3d;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Fail()
    {
        var arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NegativeInfinity_Pass()
    {
        var arg = double.NegativeInfinity;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Fail()
    {
        var arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NegativeInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegativeInfinity_Pass()
    {
        var arg = 4d;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Fail()
    {
        var arg = double.NegativeInfinity;

        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Pass()
    {
        var arg = 0d;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        var arg = 1d;

        Action act = () => Guard.Argument(arg).Zero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotZero_Pass()
    {
        var arg = 1d;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        var arg = 0d;

        Action act = () => Guard.Argument(arg).NotZero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        var arg = 1.5d;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        var arg = 0d;

        Action act = () => Guard.Argument(arg).Positive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        var arg = 0d;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        var arg = 0.1d;

        Action act = () => Guard.Argument(arg).NotPositive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        var arg = -0.5d;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        var arg = 0d;

        Action act = () => Guard.Argument(arg).Negative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        var arg = 0d;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        var arg = -1d;

        Action act = () => Guard.Argument(arg).NotNegative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





