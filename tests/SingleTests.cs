using Shouldly;

namespace ArgDefender.Test;

public class SingleTests
{
    [Test]
    public void NaN_Pass()
    {
        // Arrange
        var arg = float.NaN;

        // Act
        var act = () => Guard.Argument(arg).NaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Fail()
    {
        // Arrange
        var arg = 1f;

        // Act
        Action act = () => Guard.Argument(arg).NaN();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNaN_Pass()
    {
        // Arrange
        var arg = 2f;

        // Act
        var act = () => Guard.Argument(arg).NotNaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Fail()
    {
        // Arrange
        var arg = float.NaN;

        // Act
        Action act = () => Guard.Argument(arg).NotNaN();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Infinity_Pass_Positive()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).Infinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Pass_Negative()
    {
        // Arrange
        var arg = float.NegativeInfinity;

        // Act
        var act = () => Guard.Argument(arg).Infinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Fail()
    {
        // Arrange
        var arg = 10f;

        // Act
        Action act = () => Guard.Argument(arg).Infinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotInfinity_Pass()
    {
        // Arrange
        var arg = 5f;

        // Act
        var act = () => Guard.Argument(arg).NotInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Fail()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotInfinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Finite_Pass()
    {
        // Arrange
        var arg = 1f;

        // Act
        var act = () => Guard.Argument(arg).Finite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Fail()
    {
        // Arrange
        var arg = float.NaN;

        // Act
        Action act = () => Guard.Argument(arg).Finite();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotFinite_Pass()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).NotFinite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Fail()
    {
        // Arrange
        var arg = 1f;

        // Act
        Action act = () => Guard.Argument(arg).NotFinite();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void PositiveInfinity_Pass()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).PositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Fail()
    {
        // Arrange
        var arg = float.NegativeInfinity;

        // Act
        Action act = () => Guard.Argument(arg).PositiveInfinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositiveInfinity_Pass()
    {
        // Arrange
        var arg = 3f;

        // Act
        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Fail()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NegativeInfinity_Pass()
    {
        // Arrange
        var arg = float.NegativeInfinity;

        // Act
        var act = () => Guard.Argument(arg).NegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Fail()
    {
        // Arrange
        var arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NegativeInfinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegativeInfinity_Pass()
    {
        // Arrange
        var arg = 4f;

        // Act
        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Fail()
    {
        // Arrange
        var arg = float.NegativeInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Pass()
    {
        // Arrange
        var arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        // Arrange
        var arg = 1f;

        // Act
        Action act = () => Guard.Argument(arg).Zero();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotZero_Pass()
    {
        // Arrange
        var arg = 1f;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        // Arrange
        var arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).NotZero();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        // Arrange
        var arg = 1.5f;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        // Arrange
        var arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).Positive();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        // Arrange
        var arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        // Arrange
        var arg = 0.1f;

        // Act
        Action act = () => Guard.Argument(arg).NotPositive();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        // Arrange
        var arg = -0.5f;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        // Arrange
        var arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).Negative();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        // Arrange
        var arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        // Arrange
        var arg = -1f;

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NaN_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Pass_NaN()
    {
        // Arrange
        float? arg = float.NaN;

        // Act
        var act = () => Guard.Argument(arg).NaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NaN_Nullable_Fail()
    {
        // Arrange
        float? arg = 1f;

        // Act
        Action act = () => Guard.Argument(arg).NaN();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotNaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 2f;

        // Act
        var act = () => Guard.Argument(arg).NotNaN();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNaN_Nullable_Fail()
    {
        // Arrange
        float? arg = float.NaN;

        // Act
        Action act = () => Guard.Argument(arg).NotNaN();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Infinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Infinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Pass_PositiveInfinity()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).Infinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Infinity_Nullable_Fail()
    {
        // Arrange
        float? arg = 10f;

        // Act
        Action act = () => Guard.Argument(arg).Infinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 1f;

        // Act
        var act = () => Guard.Argument(arg).NotInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotInfinity_Nullable_Fail()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotInfinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Finite_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Finite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 1f;

        // Act
        var act = () => Guard.Argument(arg).Finite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Finite_Nullable_Fail()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).Finite();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotFinite_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotFinite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Pass_PositiveInfinity()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).NotFinite();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotFinite_Nullable_Fail()
    {
        // Arrange
        float? arg = 2f;

        // Act
        Action act = () => Guard.Argument(arg).NotFinite();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).PositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Pass_PositiveInfinity()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        var act = () => Guard.Argument(arg).PositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void PositiveInfinity_Nullable_Fail()
    {
        // Arrange
        float? arg = float.NegativeInfinity;

        // Act
        Action act = () => Guard.Argument(arg).PositiveInfinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 3f;

        // Act
        var act = () => Guard.Argument(arg).NotPositiveInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositiveInfinity_Nullable_Fail()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotPositiveInfinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Pass_NegativeInfinity()
    {
        // Arrange
        float? arg = float.NegativeInfinity;

        // Act
        var act = () => Guard.Argument(arg).NegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NegativeInfinity_Nullable_Fail()
    {
        // Arrange
        float? arg = float.PositiveInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NegativeInfinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 4f;

        // Act
        var act = () => Guard.Argument(arg).NotNegativeInfinity();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegativeInfinity_Nullable_Fail()
    {
        // Arrange
        float? arg = float.NegativeInfinity;

        // Act
        Action act = () => Guard.Argument(arg).NotNegativeInfinity();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Zero_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Pass_Zero()
    {
        // Arrange
        float? arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Fail()
    {
        // Arrange
        float? arg = 1f;

        // Act
        Action act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotZero_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 1f;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Fail()
    {
        // Arrange
        float? arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Positive_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = 1.5f;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Fail()
    {
        // Arrange
        float? arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Zero()
    {
        // Arrange
        float? arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Fail()
    {
        // Arrange
        float? arg = 0.1f;

        // Act
        Action act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Negative_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Pass_Value()
    {
        // Arrange
        float? arg = -0.5f;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Fail()
    {
        // Arrange
        float? arg = 0f;

        // Act
        Action act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Null()
    {
        // Arrange
        float? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Zero()
    {
        // Arrange
        float? arg = 0f;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Fail()
    {
        // Arrange
        float? arg = -1f;

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }
}





