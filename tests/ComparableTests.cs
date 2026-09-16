using Shouldly;

namespace ArgDefender.Test;

public class ComparableTests
{
    [Test]
    public void Min_Pass()
    {
        // Arrange
        var arg = 5;

        // Act
        var act = () => Guard.Argument(arg).Min(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Min_Fail()
    {
        // Arrange
        var arg = 2;

        // Act
        Action act = () => Guard.Argument(arg).Min(3);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void GreaterThan_Pass()
    {
        // Arrange
        var arg = 5;

        // Act
        var act = () => Guard.Argument(arg).GreaterThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void GreaterThan_Fail()
    {
        // Arrange
        var arg = 3;

        // Act
        Action act = () => Guard.Argument(arg).GreaterThan(3);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Max_Pass()
    {
        // Arrange
        var arg = 5;

        // Act
        var act = () => Guard.Argument(arg).Max(6);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Max_Fail()
    {
        // Arrange
        var arg = 7;

        // Act
        Action act = () => Guard.Argument(arg).Max(6);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void LessThan_Pass()
    {
        // Arrange
        var arg = 2;

        // Act
        var act = () => Guard.Argument(arg).LessThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void LessThan_Fail()
    {
        // Arrange
        var arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).LessThan(3);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InRange_Pass()
    {
        // Arrange
        var arg = 5;

        // Act
        var act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InRange_Fail_Below()
    {
        // Arrange
        var arg = 2;

        // Act
        Action act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InRange_Fail_Above()
    {
        // Arrange
        var arg = 8;

        // Act
        Action act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Pass()
    {
        // Arrange
        var arg = 0;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        // Arrange
        var arg = 1;

        // Act
        Action act = () => Guard.Argument(arg).Zero();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotZero_Pass()
    {
        // Arrange
        var arg = 2;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        // Arrange
        var arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).NotZero();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Positive_Pass()
    {
        // Arrange
        var arg = 1;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        // Arrange
        var arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).Positive();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotPositive_Pass()
    {
        // Arrange
        var arg = 0;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        // Arrange
        var arg = 1;

        // Act
        Action act = () => Guard.Argument(arg).NotPositive();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Negative_Pass()
    {
        // Arrange
        var arg = -1;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        // Arrange
        var arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).Negative();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNegative_Pass()
    {
        // Arrange
        var arg = 0;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        // Arrange
        var arg = -1;

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        var exception = act.ShouldThrow<ArgumentOutOfRangeException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Min_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Min(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Min_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        var act = () => Guard.Argument(arg).Min(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Min_Nullable_Fail()
    {
        // Arrange
        int? arg = 2;

        // Act
        Action act = () => Guard.Argument(arg).Min(3);

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void GreaterThan_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).GreaterThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void GreaterThan_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 4;

        // Act
        var act = () => Guard.Argument(arg).GreaterThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void GreaterThan_Nullable_Fail()
    {
        // Arrange
        int? arg = 3;

        // Act
        Action act = () => Guard.Argument(arg).GreaterThan(3);

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Max_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Max(6);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Max_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        var act = () => Guard.Argument(arg).Max(6);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Max_Nullable_Fail()
    {
        // Arrange
        int? arg = 7;

        // Act
        Action act = () => Guard.Argument(arg).Max(6);

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void LessThan_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).LessThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void LessThan_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 2;

        // Act
        var act = () => Guard.Argument(arg).LessThan(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void LessThan_Nullable_Fail()
    {
        // Arrange
        int? arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).LessThan(3);

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void InRange_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InRange_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        var act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InRange_Nullable_Fail()
    {
        // Arrange
        int? arg = 2;

        // Act
        Action act = () => Guard.Argument(arg).InRange(3, 7);

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Zero_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Pass_Zero()
    {
        // Arrange
        int? arg = 0;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Fail()
    {
        // Arrange
        int? arg = 1;

        // Act
        Action act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void NotZero_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 2;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Fail()
    {
        // Arrange
        int? arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Positive_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 1;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Fail()
    {
        // Arrange
        int? arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Zero()
    {
        // Arrange
        int? arg = 0;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Fail()
    {
        // Arrange
        int? arg = 1;

        // Act
        Action act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Negative_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = -1;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Fail()
    {
        // Arrange
        int? arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Zero()
    {
        // Arrange
        int? arg = 0;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Fail()
    {
        // Arrange
        int? arg = -1;

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldThrow<ArgumentOutOfRangeException>();
    }
}





