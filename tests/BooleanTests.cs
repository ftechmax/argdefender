using Shouldly;

namespace ArgDefender.Test;

public class BooleanTests
{
    [Test]
    public void True_Pass()
    {
        var arg = true;

        var act = () => Guard.Argument(arg).True();

        act.ShouldNotThrow();
    }

    [Test]
    public void True_Fail()
    {
        var arg = false;

        Action act = () => Guard.Argument(arg).True();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void True_Nullable_Pass()
    {
        bool? arg = true;

        var act = () => Guard.Argument(arg).True();

        act.ShouldNotThrow();
    }

    [Test]
    public void True_Nullable_Fail_False()
    {
        bool? arg = false;

        Action act = () => Guard.Argument(arg).True();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void True_Nullable_Fail_Null()
    {
        bool? arg = null;

        Action act = () => Guard.Argument(arg).True();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Pass()
    {
        var arg = false;

        var act = () => Guard.Argument(arg).False();

        act.ShouldNotThrow();
    }

    [Test]
    public void False_Fail()
    {
        var arg = true;

        Action act = () => Guard.Argument(arg).False();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Nullable_Pass()
    {
        bool? arg = false;

        var act = () => Guard.Argument(arg).False();

        act.ShouldNotThrow();
    }

    [Test]
    public void False_Nullable_Fail_True()
    {
        bool? arg = true;

        Action act = () => Guard.Argument(arg).False();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void False_Nullable_Fail_Null()
    {
        bool? arg = null;

        Action act = () => Guard.Argument(arg).False();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





