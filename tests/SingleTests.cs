using Shouldly;

namespace ArgDefender.Test;

public class SingleTests
{
    [Test]
    public void NaN_Pass()
    {
        var arg = float.NaN;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Fail()
    {
        var arg = 1f;

        Action act = () => Guard.Argument(arg).NaN();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNaN_Pass()
    {
        var arg = 2f;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Fail()
    {
        var arg = float.NaN;

        Action act = () => Guard.Argument(arg).NotNaN();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Infinity_Pass_Positive()
    {
        var arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Pass_Negative()
    {
        var arg = float.NegativeInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Fail()
    {
        var arg = 10f;

        Action act = () => Guard.Argument(arg).Infinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotInfinity_Pass()
    {
        var arg = 5f;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Fail()
    {
        var arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Finite_Pass()
    {
        var arg = 1f;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Fail()
    {
        var arg = float.NaN;

        Action act = () => Guard.Argument(arg).Finite();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotFinite_Pass()
    {
        var arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Fail()
    {
        var arg = 1f;

        Action act = () => Guard.Argument(arg).NotFinite();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void PositiveInfinity_Pass()
    {
        var arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Fail()
    {
        var arg = float.NegativeInfinity;

        Action act = () => Guard.Argument(arg).PositiveInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositiveInfinity_Pass()
    {
        var arg = 3f;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Fail()
    {
        var arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NegativeInfinity_Pass()
    {
        var arg = float.NegativeInfinity;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Fail()
    {
        var arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NegativeInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegativeInfinity_Pass()
    {
        var arg = 4f;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Fail()
    {
        var arg = float.NegativeInfinity;

        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Pass()
    {
        var arg = 0f;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        var arg = 1f;

        Action act = () => Guard.Argument(arg).Zero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotZero_Pass()
    {
        var arg = 1f;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        var arg = 0f;

        Action act = () => Guard.Argument(arg).NotZero();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        var arg = 1.5f;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        var arg = 0f;

        Action act = () => Guard.Argument(arg).Positive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        var arg = 0f;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        var arg = 0.1f;

        Action act = () => Guard.Argument(arg).NotPositive();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        var arg = -0.5f;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        var arg = 0f;

        Action act = () => Guard.Argument(arg).Negative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        var arg = 0f;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        var arg = -1f;

        Action act = () => Guard.Argument(arg).NotNegative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NaN_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Pass_NaN()
    {
        float? arg = float.NaN;

        var act = () => Guard.Argument(arg).NaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Fail()
    {
        float? arg = 1f;

        Action act = () => Guard.Argument(arg).NaN();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Value()
    {
        float? arg = 2f;

        var act = () => Guard.Argument(arg).NotNaN();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Fail()
    {
        float? arg = float.NaN;

        Action act = () => Guard.Argument(arg).NotNaN();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Infinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Pass_PositiveInfinity()
    {
        float? arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).Infinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Fail()
    {
        float? arg = 10f;

        Action act = () => Guard.Argument(arg).Infinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Value()
    {
        float? arg = 1f;

        var act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Fail()
    {
        float? arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Finite_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Pass_Value()
    {
        float? arg = 1f;

        var act = () => Guard.Argument(arg).Finite();

        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Fail()
    {
        float? arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).Finite();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotFinite_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Pass_PositiveInfinity()
    {
        float? arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).NotFinite();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Fail()
    {
        float? arg = 2f;

        Action act = () => Guard.Argument(arg).NotFinite();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_PositiveInfinity()
    {
        float? arg = float.PositiveInfinity;

        var act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Fail()
    {
        float? arg = float.NegativeInfinity;

        Action act = () => Guard.Argument(arg).PositiveInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Value()
    {
        float? arg = 3f;

        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Fail()
    {
        float? arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_NegativeInfinity()
    {
        float? arg = float.NegativeInfinity;

        var act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Fail()
    {
        float? arg = float.PositiveInfinity;

        Action act = () => Guard.Argument(arg).NegativeInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Value()
    {
        float? arg = 4f;

        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Fail()
    {
        float? arg = float.NegativeInfinity;

        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Zero_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Pass_Zero()
    {
        float? arg = 0f;

        var act = () => Guard.Argument(arg).Zero();

        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Fail()
    {
        float? arg = 1f;

        Action act = () => Guard.Argument(arg).Zero();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotZero_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Pass_Value()
    {
        float? arg = 1f;

        var act = () => Guard.Argument(arg).NotZero();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Fail()
    {
        float? arg = 0f;

        Action act = () => Guard.Argument(arg).NotZero();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Positive_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Pass_Value()
    {
        float? arg = 1.5f;

        var act = () => Guard.Argument(arg).Positive();

        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Fail()
    {
        float? arg = 0f;

        Action act = () => Guard.Argument(arg).Positive();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Zero()
    {
        float? arg = 0f;

        var act = () => Guard.Argument(arg).NotPositive();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Fail()
    {
        float? arg = 0.1f;

        Action act = () => Guard.Argument(arg).NotPositive();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Negative_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Pass_Value()
    {
        float? arg = -0.5f;

        var act = () => Guard.Argument(arg).Negative();

        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Fail()
    {
        float? arg = 0f;

        Action act = () => Guard.Argument(arg).Negative();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Null()
    {
        float? arg = null;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Zero()
    {
        float? arg = 0f;

        var act = () => Guard.Argument(arg).NotNegative();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Fail()
    {
        float? arg = -1f;

        Action act = () => Guard.Argument(arg).NotNegative();

        act.ShouldThrow<ArgumentException>();
    }
}





