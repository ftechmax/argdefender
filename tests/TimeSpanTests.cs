using Shouldly;

namespace ArgDefender.Test;

public class TimeSpanTests
{
    [Test]
    public void Zero_Pass()
    {
        // Arrange
        var arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Fail()
    {
        // Arrange
        var arg = TimeSpan.FromSeconds(1);

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
        var arg = TimeSpan.FromMilliseconds(10);

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Fail()
    {
        // Arrange
        var arg = TimeSpan.Zero;

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
        var arg = TimeSpan.FromSeconds(2);

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Fail()
    {
        // Arrange
        var arg = TimeSpan.Zero;

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
        var arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Fail()
    {
        // Arrange
        var arg = TimeSpan.FromSeconds(1);

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
        var arg = TimeSpan.FromSeconds(-1);

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Fail()
    {
        // Arrange
        var arg = TimeSpan.Zero;

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
        var arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Fail()
    {
        // Arrange
        var arg = TimeSpan.FromSeconds(-1);

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Zero_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Pass_Zero()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Zero_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(1);

        // Act
        Action act = () => Guard.Argument(arg).Zero();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotZero_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Pass_Value()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(1);

        // Act
        var act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotZero_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        Action act = () => Guard.Argument(arg).NotZero();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Positive_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Pass_Value()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(2);

        // Act
        var act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Positive_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        Action act = () => Guard.Argument(arg).Positive();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Pass_Zero()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotPositive_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(1);

        // Act
        Action act = () => Guard.Argument(arg).NotPositive();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Negative_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Pass_Value()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(-1);

        // Act
        var act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Negative_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        Action act = () => Guard.Argument(arg).Negative();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Null()
    {
        // Arrange
        TimeSpan? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Pass_Zero()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.Zero;

        // Act
        var act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNegative_Nullable_Fail()
    {
        // Arrange
        TimeSpan? arg = TimeSpan.FromSeconds(-1);

        // Act
        Action act = () => Guard.Argument(arg).NotNegative();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }
}





