using Shouldly;

namespace ArgDefender.Test;

public class GuidTests
{
    [Test]
    public void Empty_Pass_When_Empty()
    {
        var arg = Guid.Empty;

        var act = () => Guard.Argument(arg).Empty();

        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Pass_When_Nullable_Null()
    {
        Guid? arg = null;

        var act = () => Guard.Argument(arg).Empty();

        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Fail_When_NotEmpty()
    {
        var arg = Guid.NewGuid();

        Action act = () => Guard.Argument(arg).Empty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Empty_Fail_When_Nullable_NotEmpty()
    {
        Guid? arg = Guid.NewGuid();

        Action act = () => Guard.Argument(arg).Empty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Pass_When_NotEmpty()
    {
        var arg = Guid.NewGuid();

        var act = () => Guard.Argument(arg).NotEmpty();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Pass_When_Nullable_Null()
    {
        Guid? arg = null;

        var act = () => Guard.Argument(arg).NotEmpty();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Fail_When_Empty()
    {
        var arg = Guid.Empty;

        Action act = () => Guard.Argument(arg).NotEmpty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Fail_When_Nullable_Empty()
    {
        Guid? arg = Guid.Empty;

        Action act = () => Guard.Argument(arg).NotEmpty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





