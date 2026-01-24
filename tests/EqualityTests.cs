using Shouldly;

namespace ArgDefender.Test;

public class EqualityTests
{
    private sealed class RefHolder
    {
        public int Value { get; }
        public RefHolder(int value) => Value = value;
    }

    [Test]
    public void Default_Pass()
    {
        var arg = 0;

        var act = () => Guard.Argument(arg).Default();

        act.ShouldNotThrow();
    }

    [Test]
    public void Default_Fail()
    {
        var arg = 5;

        Action act = () => Guard.Argument(arg).Default();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Default_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).Default();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Pass()
    {
        var arg = 2;

        var act = () => Guard.Argument(arg).NotDefault();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Fail()
    {
        var arg = 0;

        Action act = () => Guard.Argument(arg).NotDefault();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotDefault_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).NotDefault();

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Pass()
    {
        var arg = "hello";

        var act = () => Guard.Argument(arg).Equal("hello");

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Fail()
    {
        var arg = "hello";

        Action act = () => Guard.Argument(arg).Equal("world");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Equal_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).Equal(5);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Pass()
    {
        var arg = 1.0d;

        var act = () => Guard.Argument(arg).Equal(1.05d, 0.1d);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Fail()
    {
        var arg = 1.0d;

        Action act = () => Guard.Argument(arg).Equal(1.2d, 0.1d);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Pass()
    {
        var arg = 10;

        var act = () => Guard.Argument(arg).NotEqual(20);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Fail()
    {
        var arg = 10;

        Action act = () => Guard.Argument(arg).NotEqual(10);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Nullable_Pass_Null()
    {
        int? arg = null;

        var act = () => Guard.Argument(arg).NotEqual(5);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Pass()
    {
        var arg = 1.0d;

        var act = () => Guard.Argument(arg).NotEqual(1.2d, 0.1d);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Fail()
    {
        var arg = 1.0d;

        Action act = () => Guard.Argument(arg).NotEqual(1.05d, 0.1d);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Equal_Delta_Float_Pass_NonNullable()
    {
        var arg = 1.05f;

        var act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Float_Fail_NonNullable()
    {
        var arg = 1.2f;

        Action act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEqual_Delta_Float_Pass_NonNullable()
    {
        var arg = 1.2f;

        var act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Float_Fail_NonNullable()
    {
        var arg = 1.05f;

        Action act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Same_Pass()
    {
        var instance = new RefHolder(1);

        var act = () => Guard.Argument(instance).Same(instance);

        act.ShouldNotThrow();
    }

    [Test]
    public void Same_Fail()
    {
        var arg = new RefHolder(1);
        var other = new RefHolder(1);

        Action act = () => Guard.Argument(arg).Same(other);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotSame_Pass()
    {
        var arg = new RefHolder(1);
        var other = new RefHolder(2);

        var act = () => Guard.Argument(arg).NotSame(other);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotSame_Fail()
    {
        var arg = new RefHolder(1);

        Action act = () => Guard.Argument(arg).NotSame(arg);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Default_Nullable_Fail_Value()
    {
        int? arg = 5;

        Action act = () => Guard.Argument(arg).Default();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotDefault_Nullable_Pass_Value()
    {
        int? arg = 2;

        var act = () => Guard.Argument(arg).NotDefault();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotDefault_Nullable_Fail_Default()
    {
        int? arg = 0;

        Action act = () => Guard.Argument(arg).NotDefault();

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Nullable_Pass_Value()
    {
        int? arg = 5;

        var act = () => Guard.Argument(arg).Equal(5);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Nullable_Fail_Value()
    {
        int? arg = 4;

        Action act = () => Guard.Argument(arg).Equal(5);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Nullable_Pass_Value()
    {
        int? arg = 4;

        var act = () => Guard.Argument(arg).NotEqual(5);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Nullable_Fail_Value()
    {
        int? arg = 5;

        Action act = () => Guard.Argument(arg).NotEqual(5);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Delta_Double_Nullable_Pass()
    {
        double? arg = 1.05d;

        var act = () => Guard.Argument(arg).Equal(1.0d, 0.1d);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Double_Nullable_Fail()
    {
        double? arg = 1.2d;

        Action act = () => Guard.Argument(arg).Equal(1.0d, 0.1d);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Delta_Double_Nullable_Pass()
    {
        double? arg = 1.2d;

        var act = () => Guard.Argument(arg).NotEqual(1.0d, 0.1d);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Double_Nullable_Fail()
    {
        double? arg = 1.05d;

        Action act = () => Guard.Argument(arg).NotEqual(1.0d, 0.1d);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Equal_Delta_Float_Nullable_Pass()
    {
        float? arg = 1.05f;

        var act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        act.ShouldNotThrow();
    }

    [Test]
    public void Equal_Delta_Float_Nullable_Fail()
    {
        float? arg = 1.2f;

        Action act = () => Guard.Argument(arg).Equal(1.0f, 0.1f);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void NotEqual_Delta_Float_Nullable_Pass()
    {
        float? arg = 1.2f;

        var act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEqual_Delta_Float_Nullable_Fail()
    {
        float? arg = 1.05f;

        Action act = () => Guard.Argument(arg).NotEqual(1.0f, 0.1f);

        act.ShouldThrow<ArgumentException>();
    }
}





