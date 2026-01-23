using Shouldly;

namespace ArgDefender.Test;

public class NullTests
{
    [Test]
    public void Null_Pass_Reference()
    {
        string? arg = null;

        var act = () => Guard.Argument(arg).Null();

        act.ShouldNotThrow();
    }

    [Test]
    public void Null_Fail_Reference()
    {
        var arg = "value";

        Action act = () => Guard.Argument(arg).Null();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Null_Pass_NullableStruct()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).Null();

        act.ShouldNotThrow();
    }

    [Test]
    public void Null_Fail_NullableStruct()
    {
        int? arg = 1;

        Action act = () => Guard.Argument(arg).Null();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNull_Pass_Reference()
    {
        var arg = "value";

        var act = () => Guard.Argument(arg).NotNull();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNull_Fail_Reference()
    {
        string? arg = null;

        Action act = () => Guard.Argument(arg).NotNull();

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotNull_Pass_NullableStruct()
    {
        int? arg = 1;

        var act = () => Guard.Argument(arg).NotNull();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotNull_Fail_NullableStruct()
    {
        int? arg = null;

        Action act = () => Guard.Argument(arg).NotNull();

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotAllNull_Two_Pass_When_First_NotNull()
    {
        string? arg1 = "a";
        string? arg2 = null;

        var act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2));

        act.ShouldNotThrow();
    }

    [Test]
    public void NotAllNull_Two_Fail_When_BothNull()
    {
        string? arg1 = null;
        string? arg2 = null;

        Action act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2));

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg1));
        exception.Message.ShouldContain(nameof(arg2));
    }

    [Test]
    public void NotAllNull_Three_Pass_When_OneNotNull()
    {
        string? arg1 = null;
        string? arg2 = "b";
        string? arg3 = null;

        var act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2), Guard.Argument(arg3));

        act.ShouldNotThrow();
    }

    [Test]
    public void NotAllNull_Three_Fail_When_AllNull()
    {
        string? arg1 = null;
        string? arg2 = null;
        string? arg3 = null;

        Action act = () => Guard.NotAllNull(Guard.Argument(arg1), Guard.Argument(arg2), Guard.Argument(arg3));

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.Message.ShouldContain(nameof(arg1));
        exception.Message.ShouldContain(nameof(arg2));
        exception.Message.ShouldContain(nameof(arg3));
    }
}





