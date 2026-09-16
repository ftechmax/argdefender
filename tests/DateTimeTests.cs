using Shouldly;

namespace ArgDefender.Test;

public class DateTimeTests
{
    [Test]
    public void KindSpecified_DateTime_Pass()
    {
        // Arrange
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        var act = () => Guard.Argument(arg).KindSpecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_DateTime_Fail()
    {
        // Arrange
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        // Act
        Action act = () => Guard.Argument(arg).KindSpecified();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Pass_Null()
    {
        // Arrange
        DateTime? arg = null;

        // Act
        var act = () => Guard.Argument(arg).KindSpecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Pass_Value()
    {
        // Arrange
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);

        // Act
        var act = () => Guard.Argument(arg).KindSpecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Fail()
    {
        // Arrange
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        // Act
        Action act = () => Guard.Argument(arg).KindSpecified();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_DateTime_Pass()
    {
        // Arrange
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        // Act
        var act = () => Guard.Argument(arg).KindUnspecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_DateTime_Fail()
    {
        // Arrange
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        Action act = () => Guard.Argument(arg).KindUnspecified();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Pass_Null()
    {
        // Arrange
        DateTime? arg = null;

        // Act
        var act = () => Guard.Argument(arg).KindUnspecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Pass_Value()
    {
        // Arrange
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        // Act
        var act = () => Guard.Argument(arg).KindUnspecified();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Fail()
    {
        // Arrange
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);

        // Act
        Action act = () => Guard.Argument(arg).KindUnspecified();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





