using Shouldly;

namespace ArgDefender.Test;

public class NullTests
{
    [Test]
    public void Null_Pass_Reference()
    {
        // Arrange
        string? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Null();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Null_Fail_Reference()
    {
        // Arrange
        var arg = "value";

        // Act
        Action act = () => Guard.Argument(arg).Null();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Null_Pass_NullableStruct()
    {
        // Arrange
        int? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Null();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Null_Fail_NullableStruct()
    {
        // Arrange
        int? arg = 1;

        // Act
        Action act = () => Guard.Argument(arg).Null();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNull_Pass_Reference()
    {
        // Arrange
        var arg = "value";

        // Act
        var act = () => Guard.Argument(arg).NotNull();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNull_Fail_Reference()
    {
        // Arrange
        string? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).NotNull();

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNull_Pass_NullableStruct()
    {
        // Arrange
        int? arg = 1;

        // Act
        var act = () => Guard.Argument(arg).NotNull();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotNull_Fail_NullableStruct()
    {
        // Arrange
        int? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).NotNull();

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotAllNull_Two_Pass_When_First_NotNull()
    {
        // Arrange
        string? arg1 = "a";
        string? arg2 = null;

        // Act
        var act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotAllNull_Two_Fail_When_BothNull()
    {
        // Arrange
        string? arg1 = null;
        string? arg2 = null;

        // Act
        Action act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2));

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg1));
        exception.Message.ShouldContain(nameof(arg2));
    }

    [Test]
    public void NotAllNull_Three_Pass_When_OneNotNull()
    {
        // Arrange
        string? arg1 = null;
        string? arg2 = "b";
        string? arg3 = null;

        // Act
        var act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2), Guard.Argument(arg3));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotAllNull_Three_Fail_When_AllNull()
    {
        // Arrange
        string? arg1 = null;
        string? arg2 = null;
        string? arg3 = null;

        // Act
        Action act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2), Guard.Argument(arg3));

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg1));
        exception.Message.ShouldContain(nameof(arg2));
        exception.Message.ShouldContain(nameof(arg3));
    }
}





