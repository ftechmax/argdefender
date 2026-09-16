using Shouldly;

namespace ArgDefender.Test;

public class BooleanTests
{
    [Test]
    public void True_Pass()
    {
        // Arrange
        var arg = true;

        // Act
        var act = () => Guard.Argument(arg).True();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void True_Fail()
    {
        // Arrange
        var arg = false;

        // Act
        Action act = () => Guard.Argument(arg).True();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void True_Nullable_Pass()
    {
        // Arrange
        bool? arg = true;

        // Act
        var act = () => Guard.Argument(arg).True();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void True_Nullable_Fail_False()
    {
        // Arrange
        bool? arg = false;

        // Act
        Action act = () => Guard.Argument(arg).True();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void True_Nullable_Fail_Null()
    {
        // Arrange
        bool? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).True();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Pass()
    {
        // Arrange
        var arg = false;

        // Act
        var act = () => Guard.Argument(arg).False();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void False_Fail()
    {
        // Arrange
        var arg = true;

        // Act
        Action act = () => Guard.Argument(arg).False();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Nullable_Pass()
    {
        // Arrange
        bool? arg = false;

        // Act
        var act = () => Guard.Argument(arg).False();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void False_Nullable_Fail_True()
    {
        // Arrange
        bool? arg = true;

        // Act
        Action act = () => Guard.Argument(arg).False();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Nullable_Fail_Null()
    {
        // Arrange
        bool? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).False();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





