using Shouldly;

namespace ArgDefender.Test;

public class EnumTests
{
    private enum Sample
    {
        None = 0,
        One = 1,
        Two = 2,
    }

    [Flags]
    private enum SampleOptions
    {
        One = 1,
        Two = 2,
        Three = One | Two,
    }

    [Test]
    public void Enum_Pass()
    {
        // Arrange
        var arg = Sample.One;

        // Act
        var act = () => Guard.Argument(arg).Enum();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Enum_Fail()
    {
        // Arrange
        var arg = (Sample)99;

        // Act
        Action act = () => Guard.Argument(arg).Enum();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Enum_Nullable_Null_Pass()
    {
        // Arrange
        Sample? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Enum();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDefined_Pass()
    {
        // Arrange
        var arg = Sample.Two;

        // Act
        var act = () => Guard.Argument(arg).EnumDefined();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDefined_Fail()
    {
        // Arrange
        var arg = (Sample)5;

        // Act
        Action act = () => Guard.Argument(arg).EnumDefined();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNone_Pass()
    {
        // Arrange
        var arg = Sample.None;

        // Act
        var act = () => Guard.Argument(arg).EnumNone();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNone_Fail()
    {
        // Arrange
        var arg = Sample.One;

        // Act
        Action act = () => Guard.Argument(arg).EnumNone();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNotNone_Pass()
    {
        // Arrange
        var arg = Sample.One;

        // Act
        var act = () => Guard.Argument(arg).EnumNotNone();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNotNone_Fail()
    {
        // Arrange
        var arg = Sample.None;

        // Act
        Action act = () => Guard.Argument(arg).EnumNotNone();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumHasFlag_Pass()
    {
        // Arrange
        var arg = SampleOptions.Three;

        // Act
        var act = () => Guard.Argument(arg).EnumHasFlag(SampleOptions.One);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumHasFlag_Fail()
    {
        // Arrange
        var arg = SampleOptions.One;

        // Act
        Action act = () => Guard.Argument(arg).EnumHasFlag(SampleOptions.Two);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumDoesNotHaveFlag_Pass()
    {
        // Arrange
        var arg = SampleOptions.One;

        // Act
        var act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleOptions.Two);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDoesNotHaveFlag_Fail()
    {
        // Arrange
        var arg = SampleOptions.Three;

        // Act
        Action act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleOptions.One);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNullable_Flag_Pass_WhenNull()
    {
        // Arrange
        SampleOptions? arg = null;

        // Act
        var act = () => Guard.Argument(arg).EnumHasFlag(SampleOptions.One);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDefined_Nullable_Pass_Value()
    {
        // Arrange
        Sample? arg = Sample.Two;

        // Act
        var act = () => Guard.Argument(arg).EnumDefined();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNone_Nullable_Pass_Value()
    {
        // Arrange
        Sample? arg = Sample.None;

        // Act
        var act = () => Guard.Argument(arg).EnumNone();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNotNone_Nullable_Pass_Value()
    {
        // Arrange
        Sample? arg = Sample.One;

        // Act
        var act = () => Guard.Argument(arg).EnumNotNone();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumHasFlag_Nullable_Pass_Value()
    {
        // Arrange
        SampleOptions? arg = SampleOptions.Three;

        // Act
        var act = () => Guard.Argument(arg).EnumHasFlag(SampleOptions.One);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDoesNotHaveFlag_Nullable_Pass_Value()
    {
        // Arrange
        SampleOptions? arg = SampleOptions.One;

        // Act
        var act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleOptions.Two);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDoesNotHaveFlag_Nullable_Pass_Null()
    {
        // Arrange
        SampleOptions? arg = null;

        // Act
        var act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleOptions.One);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNullable_Pass_Value()
    {
        // Arrange
        Sample? arg = Sample.One;

        // Act
        var act = () => Guard.Argument(arg).Enum();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNullable_Fail_Value()
    {
        // Arrange
        Sample? arg = (Sample)99;

        // Act
        Action act = () => Guard.Argument(arg).Enum();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void EnumDefined_Nullable_Fail_Value()
    {
        // Arrange
        Sample? arg = (Sample)5;

        // Act
        Action act = () => Guard.Argument(arg).EnumDefined();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void EnumNone_Nullable_Fail_Value()
    {
        // Arrange
        Sample? arg = Sample.One;

        // Act
        Action act = () => Guard.Argument(arg).EnumNone();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void EnumNotNone_Nullable_Fail_Value()
    {
        // Arrange
        Sample? arg = Sample.None;

        // Act
        Action act = () => Guard.Argument(arg).EnumNotNone();

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void EnumHasFlag_Nullable_Fail_Value()
    {
        // Arrange
        SampleOptions? arg = SampleOptions.One;

        // Act
        Action act = () => Guard.Argument(arg).EnumHasFlag(SampleOptions.Two);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void EnumDoesNotHaveFlag_Nullable_Fail_Value()
    {
        // Arrange
        SampleOptions? arg = SampleOptions.Three;

        // Act
        Action act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleOptions.One);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }
}





