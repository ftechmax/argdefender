using Shouldly;

namespace ArgDefender.Test;

public class GuidTests
{
    [Test]
    public void Empty_Pass_When_Empty()
    {
        // Arrange
        var arg = Guid.Empty;

        // Act
        var act = () => Guard.Argument(arg).Empty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Pass_When_Nullable_Null()
    {
        // Arrange
        Guid? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Empty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Fail_When_NotEmpty()
    {
        // Arrange
        var arg = Guid.NewGuid();

        // Act
        Action act = () => Guard.Argument(arg).Empty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Empty_Fail_When_Nullable_NotEmpty()
    {
        // Arrange
        Guid? arg = Guid.NewGuid();

        // Act
        Action act = () => Guard.Argument(arg).Empty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Pass_When_NotEmpty()
    {
        // Arrange
        var arg = Guid.NewGuid();

        // Act
        var act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Pass_When_Nullable_Null()
    {
        // Arrange
        Guid? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Fail_When_Empty()
    {
        // Arrange
        var arg = Guid.Empty;

        // Act
        Action act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Fail_When_Nullable_Empty()
    {
        // Arrange
        Guid? arg = Guid.Empty;

        // Act
        Action act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





