using Shouldly;

namespace ArgDefender.Test;

public class IComparableTests
{
    [Test]
    public void Min_Pass()
    {
        var arg = 5;

        var act = () => Guard.Argument(arg).Min(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void Min_Fail()
    {
        var arg = 2;

        Action act = () => Guard.Argument(arg).Min(3);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Min_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).Min(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void GreaterThan_Pass()
    {
        var arg = 5;

        var act = () => Guard.Argument(arg).GreaterThan(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void GreaterThan_Fail()
    {
        var arg = 3;

        Action act = () => Guard.Argument(arg).GreaterThan(3);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void GreaterThan_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).GreaterThan(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void Max_Pass()
    {
        var arg = 5;

        var act = () => Guard.Argument(arg).Max(6);

        act.ShouldNotThrow();
    }

    [Test]
    public void Max_Fail()
    {
        var arg = 7;

        Action act = () => Guard.Argument(arg).Max(6);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Max_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).Max(6);

        act.ShouldNotThrow();
    }

    [Test]
    public void LessThan_Pass()
    {
        var arg = 2;

        var act = () => Guard.Argument(arg).LessThan(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void LessThan_Fail()
    {
        var arg = 5;

        Action act = () => Guard.Argument(arg).LessThan(3);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void LessThan_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).LessThan(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void InRange_Pass()
    {
        var arg = 5;

        var act = () => Guard.Argument(arg).InRange(3, 7);

        act.ShouldNotThrow();
    }

    [Test]
    public void InRange_Fail_Below()
    {
        var arg = 2;

        Action act = () => Guard.Argument(arg).InRange(3, 7);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InRange_Fail_Above()
    {
        var arg = 8;

        Action act = () => Guard.Argument(arg).InRange(3, 7);

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InRange_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).InRange(3, 7);

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Pass()
    {
        var arg = 0;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        var arg = 1;

        Action act = () => Guard.Argument(arg).Zero();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotZero_Pass()
    {
        var arg = 2;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        var arg = 0;

        Action act = () => Guard.Argument(arg).NotZero();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        var arg = 1;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        var arg = 0;

        Action act = () => Guard.Argument(arg).Positive();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        var arg = 0;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        var arg = 1;

        Action act = () => Guard.Argument(arg).NotPositive();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        var arg = -1;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        var arg = 0;

        Action act = () => Guard.Argument(arg).Negative();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        var arg = 0;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        var arg = -1;

        Action act = () => Guard.Argument(arg).NotNegative();

        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





