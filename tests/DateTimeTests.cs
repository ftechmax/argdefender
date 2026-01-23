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

    [Test]
    public void KindSpecified_DateTimeOffset_Pass()
    {
        var arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.FromHours(2));

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_DateTimeOffset_Fail()
    {
        var arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Action act = () => Guard.Argument(arg).KindSpecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindSpecified_Nullable_DateTimeOffset_Pass_Null()
    {
        DateTimeOffset? arg = null;

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTimeOffset_Pass_Value()
    {
        DateTimeOffset? arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.FromHours(1));

        var act = () => Guard.Argument(arg).KindSpecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindSpecified_Nullable_DateTimeOffset_Fail()
    {
        DateTimeOffset? arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        Action act = () => Guard.Argument(arg).KindSpecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_DateTimeOffset_Pass()
    {
        var arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_DateTimeOffset_Fail()
    {
        var arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.FromHours(-3));

        Action act = () => Guard.Argument(arg).KindUnspecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void KindUnspecified_Nullable_DateTimeOffset_Pass_Null()
    {
        DateTimeOffset? arg = null;

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTimeOffset_Pass_Value()
    {
        DateTimeOffset? arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);

        var act = () => Guard.Argument(arg).KindUnspecified();

        act.ShouldNotThrow();
    }

    [Test]
    public void KindUnspecified_Nullable_DateTimeOffset_Fail()
    {
        DateTimeOffset? arg = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.FromHours(2));

        Action act = () => Guard.Argument(arg).KindUnspecified();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





