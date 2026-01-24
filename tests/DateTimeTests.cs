using Shouldly;

namespace ArgDefender.Test;

public class DateTimeTests
{
    [Test]
    public void KindSpecified_DateTime_Pass()
    {
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_DateTime_Fail()
    {
        var arg = new DateTime(2024, 1, 1);

        Action act = () => Guard.Argument(arg).KindSpecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Pass_Null()
    {
        DateTime? arg = null;

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Pass_Value()
    {
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTime_Fail()
    {
        DateTime? arg = new DateTime(2024, 1, 1);

        Action act = () => Guard.Argument(arg).KindSpecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_DateTime_Pass()
    {
        var arg = new DateTime(2024, 1, 1);

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_DateTime_Fail()
    {
        var arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        Action act = () => Guard.Argument(arg).KindUnspecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Pass_Null()
    {
        DateTime? arg = null;

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Pass_Value()
    {
        DateTime? arg = new DateTime(2024, 1, 1);

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTime_Fail()
    {
        DateTime? arg = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);

        Action act = () => Guard.Argument(arg).KindUnspecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





