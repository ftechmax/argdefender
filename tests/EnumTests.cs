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
    private enum SampleFlags
    {
        None = 0,
        One = 1,
        Two = 2,
        Three = One | Two,
    }

    [Test]
    public void Enum_Pass()
    {
        var arg = Sample.One;

        var act = () => Guard.Argument(arg).Enum();

        act.ShouldNotThrow();
    }

    [Test]
    public void Enum_Fail()
    {
        var arg = (Sample)99;

        Action act = () => Guard.Argument(arg).Enum();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Enum_Nullable_Null_Pass()
    {
        Sample? arg = null;

        var act = () => Guard.Argument(arg).Enum();

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDefined_Pass()
    {
        var arg = Sample.Two;

        var act = () => Guard.Argument(arg).EnumDefined();

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDefined_Fail()
    {
        var arg = (Sample)5;

        Action act = () => Guard.Argument(arg).EnumDefined();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNone_Pass()
    {
        var arg = Sample.None;

        var act = () => Guard.Argument(arg).EnumNone();

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNone_Fail()
    {
        var arg = Sample.One;

        Action act = () => Guard.Argument(arg).EnumNone();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNotNone_Pass()
    {
        var arg = Sample.One;

        var act = () => Guard.Argument(arg).EnumNotNone();

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumNotNone_Fail()
    {
        var arg = Sample.None;

        Action act = () => Guard.Argument(arg).EnumNotNone();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumHasFlag_Pass()
    {
        var arg = SampleFlags.Three;

        var act = () => Guard.Argument(arg).EnumHasFlag(SampleFlags.One);

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumHasFlag_Fail()
    {
        var arg = SampleFlags.One;

        Action act = () => Guard.Argument(arg).EnumHasFlag(SampleFlags.Two);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumDoesNotHaveFlag_Pass()
    {
        var arg = SampleFlags.One;

        var act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleFlags.Two);

        act.ShouldNotThrow();
    }

    [Test]
    public void EnumDoesNotHaveFlag_Fail()
    {
        var arg = SampleFlags.Three;

        Action act = () => Guard.Argument(arg).EnumDoesNotHaveFlag(SampleFlags.One);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EnumNullable_Flag_Pass_WhenNull()
    {
        SampleFlags? arg = null;

        var act = () => Guard.Argument(arg).EnumHasFlag(SampleFlags.One);

        act.ShouldNotThrow();
    }
}





