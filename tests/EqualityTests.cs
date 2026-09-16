using Shouldly;

namespace ArgDefender.Test;

public class EqualityTests
{
    private sealed class RefHolder
    {
        public int Value { get; }
        public RefHolder(int value) => Value = value;
    }

    [Test]
    public void Default_Pass()
    {
        // Arrange
        var arg = 0;

        // Act
        var act = () => Guard.Argument(arg).Default();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Default_Fail()
    {
        // Arrange
        var arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).Default();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Default_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Default();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Pass()
    {
        // Arrange
        var arg = 2;

        // Act
        var act = () => Guard.Argument(arg).NotDefault();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Fail()
    {
        // Arrange
        var arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).NotDefault();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotDefault_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotDefault();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).Equal("hello");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).Equal("world");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Equal_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Equal(5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Pass()
    {
        // Arrange
        var arg = 1.0d;

        // Act
        var act = () => Guard.Argument(arg).Equal(1.05d, 0.1d);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Fail()
    {
        // Arrange
        var arg = 1.0d;

        // Act
        Action act = () => Guard.Argument(arg).Equal(1.2d, 0.1d);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Pass()
    {
        // Arrange
        var arg = 10;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(20);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Fail()
    {
        // Arrange
        var arg = 10;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(10);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Nullable_Pass_Null()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Pass()
    {
        // Arrange
        var arg = 1.0d;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(1.2d, 0.1d);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Fail()
    {
        // Arrange
        var arg = 1.0d;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(1.05d, 0.1d);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Equal_Delta_Float_Pass_NonNullable()
    {
        // Arrange
        var arg = 1.05f;

        // Act
        var act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Float_Fail_NonNullable()
    {
        // Arrange
        var arg = 1.2f;

        // Act
        Action act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Delta_Float_Pass_NonNullable()
    {
        // Arrange
        var arg = 1.2f;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Float_Fail_NonNullable()
    {
        // Arrange
        var arg = 1.05f;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Same_Pass()
    {
        // Arrange
        var instance = new RefHolder(1);

        // Act
        var act = () => Guard.Argument(instance).Same(instance);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Same_Fail()
    {
        // Arrange
        var arg = new RefHolder(1);
        var other = new RefHolder(1);

        // Act
        Action act = () => Guard.Argument(arg).Same(other);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotSame_Pass()
    {
        // Arrange
        var arg = new RefHolder(1);
        var other = new RefHolder(2);

        // Act
        var act = () => Guard.Argument(arg).NotSame(other);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotSame_Fail()
    {
        // Arrange
        var arg = new RefHolder(1);

        // Act
        Action act = () => Guard.Argument(arg).NotSame(arg);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Default_Nullable_Fail_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).Default();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotDefault_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 2;

        // Act
        var act = () => Guard.Argument(arg).NotDefault();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Nullable_Fail_Default()
    {
        // Arrange
        int? arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).NotDefault();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        var act = () => Guard.Argument(arg).Equal(5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Nullable_Fail_Value()
    {
        // Arrange
        int? arg = 4;

        // Act
        Action act = () => Guard.Argument(arg).Equal(5);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Nullable_Pass_Value()
    {
        // Arrange
        int? arg = 4;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Nullable_Fail_Value()
    {
        // Arrange
        int? arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(5);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Delta_Double_Nullable_Pass()
    {
        // Arrange
        double? arg = 1.05d;

        // Act
        var act = () => Guard.Argument(arg).Equal(1.0d, 0.1d);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Nullable_Fail()
    {
        // Arrange
        double? arg = 1.2d;

        // Act
        Action act = () => Guard.Argument(arg).Equal(1.0d, 0.1d);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Delta_Double_Nullable_Pass()
    {
        // Arrange
        double? arg = 1.2d;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(1.0d, 0.1d);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Nullable_Fail()
    {
        // Arrange
        double? arg = 1.05d;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(1.0d, 0.1d);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Delta_Float_Nullable_Pass()
    {
        // Arrange
        float? arg = 1.05f;

        // Act
        var act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Float_Nullable_Fail()
    {
        // Arrange
        float? arg = 1.2f;

        // Act
        Action act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Delta_Float_Nullable_Pass()
    {
        // Arrange
        float? arg = 1.2f;

        // Act
        var act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Float_Nullable_Fail()
    {
        // Arrange
        float? arg = 1.05f;

        // Act
        Action act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }
}





