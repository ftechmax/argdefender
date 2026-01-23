using Shouldly;

namespace ArgDefender.Test;

public class TypeTests
{
    private class Animal { }
    private class Dog : Animal { }

    [Test]
    public void Type_WithType_Pass()
    {
        object arg = new Dog();

        var act = () => Guard.Argument(arg).Type(typeof(Animal));

        act.ShouldNotThrow();
    }

    [Test]
    public void Type_WithType_Fail()
    {
        object arg = 5;

        Action act = () => Guard.Argument(arg).Type(typeof(string));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Type_WithType_Fail_When_Null()
    {
        object? arg = null;

        Action act = () => Guard.Argument(arg).Type(typeof(string));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Type_Generic_Pass()
    {
        object arg = new Dog();

        var act = () => Guard.Argument(arg).Type(typeof(Animal));

        act.ShouldNotThrow();
    }

    [Test]
    public void Type_Generic_Fail()
    {
        object arg = 5;

        Action act = () => Guard.Argument(arg).Type(typeof(Animal));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotType_WithType_Pass()
    {
        object arg = 5;

        var act = () => Guard.Argument(arg).NotType(typeof(string));

        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_WithType_Pass_When_Null()
    {
        object? arg = null;

        var act = () => Guard.Argument(arg).NotType(typeof(string));

        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_WithType_Fail()
    {
        object arg = "hello";

        Action act = () => Guard.Argument(arg).NotType(typeof(string));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotType_Generic_Pass()
    {
        object arg = 5;

        var act = () => Guard.Argument(arg).NotType(typeof(Animal));

        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_Generic_Fail()
    {
        object arg = new Dog();

        Action act = () => Guard.Argument(arg).NotType(typeof(Animal));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Compatible_Pass()
    {
        Dog arg = new();

        var act = () => Guard.Argument(arg).Compatible<Dog, Animal>();

        act.ShouldNotThrow();
    }

    [Test]
    public void Compatible_Fail_NotAssignable()
    {
        var arg = new Uri("http://example.com");

        Action act = () => Guard.Argument(arg).Compatible<Uri, Dog>();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Compatible_Fail_Null()
    {
        Dog? arg = null;

        Action act = () => Guard.Argument(arg).Compatible<Dog, Animal>();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotCompatible_Pass()
    {
        var arg = "hello";

        var act = () => Guard.Argument(arg).NotCompatible<string, Uri>();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotCompatible_Pass_Null()
    {
        string? arg = null;

        var act = () => Guard.Argument(arg).NotCompatible<string, Uri>();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotCompatible_Fail()
    {
        Dog arg = new();

        Action act = () => Guard.Argument(arg).NotCompatible<Dog, Animal>();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





