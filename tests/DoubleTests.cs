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
    public void Finite_Pass()
    {
        var arg = 1d;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Fail()
    {
        var arg = double.NaN;

        Action act = () => Guard.Argument(arg).Finite();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotFinite_Pass()
    {
        var arg = double.NegativeInfinity;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Fail()
    {
        var arg = 2d;

        Action act = () => Guard.Argument(arg).NotFinite();

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

    [Test]
    public void NaN_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Pass_NaN()
    {
        double? arg = double.NaN;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Fail()
    {
        double? arg = 1d;

        Action act = () => Guard.Argument(arg).NaN();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Value()
    {
        double? arg = 2d;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Fail()
    {
        double? arg = double.NaN;

        Action act = () => Guard.Argument(arg).NotNaN();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Infinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Pass_PositiveInfinity()
    {
        double? arg = double.PositiveInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Fail()
    {
        double? arg = 10d;

        Action act = () => Guard.Argument(arg).Infinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Value()
    {
        double? arg = 1d;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Fail()
    {
        double? arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Finite_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Pass_Value()
    {
        double? arg = 1d;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Fail()
    {
        double? arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).Finite();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotFinite_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Pass_PositiveInfinity()
    {
        double? arg = double.PositiveInfinity;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Fail()
    {
        double? arg = 2d;

        Action act = () => Guard.Argument(arg).NotFinite();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_PositiveInfinity()
    {
        double? arg = double.PositiveInfinity;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Fail()
    {
        double? arg = double.NegativeInfinity;

        Action act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Value()
    {
        double? arg = 3d;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Fail()
    {
        double? arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_NegativeInfinity()
    {
        double? arg = double.NegativeInfinity;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Fail()
    {
        double? arg = double.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Value()
    {
        double? arg = 4d;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Fail()
    {
        double? arg = double.NegativeInfinity;

        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Zero_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Pass_Zero()
    {
        double? arg = 0d;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Fail()
    {
        double? arg = 1d;

        Action act = () => Guard.Argument(arg).Zero();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotZero_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Pass_Value()
    {
        double? arg = 1d;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Fail()
    {
        double? arg = 0d;

        Action act = () => Guard.Argument(arg).NotZero();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Positive_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Pass_Value()
    {
        double? arg = 1.5d;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Fail()
    {
        double? arg = 0d;

        Action act = () => Guard.Argument(arg).Positive();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Zero()
    {
        double? arg = 0d;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Fail()
    {
        double? arg = 0.1d;

        Action act = () => Guard.Argument(arg).NotPositive();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Negative_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Pass_Value()
    {
        double? arg = -0.5d;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Fail()
    {
        double? arg = 0d;

        Action act = () => Guard.Argument(arg).Negative();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Null()
    {
        double? arg = null;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Zero()
    {
        double? arg = 0d;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Fail()
    {
        double? arg = -1d;

        Action act = () => Guard.Argument(arg).NotNegative();

        act.ShouldThrow<ArgumentException>();
    }
}





