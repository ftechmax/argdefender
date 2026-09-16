using Shouldly;

namespace ArgDefender.Test;

public class TypeTests
{
#pragma warning disable S2094 // Empty classes are only used to test type checks
    private class Animal { }
    private class Dog : Animal { }
#pragma warning restore S2094

    [Test]
    public void Type_WithType_Pass()
    {
        // Arrange
        object arg = new Dog();

        // Act
        var act = () => Guard.Argument(arg).Type(typeof(Animal));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Type_WithType_Fail()
    {
        // Arrange
        object arg = 5;

        // Act
        Action act = () => Guard.Argument(arg).Type(typeof(string));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Type_WithType_Fail_When_Null()
    {
        // Arrange
        object? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).Type(typeof(string));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Type_WithTypedArgument_Pass()
    {
        // Arrange
        Animal arg = new Dog();

        // Act
        var act = () => Guard.Argument(arg).Type(typeof(Dog));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Type_WithTypedArgument_Fail()
    {
        // Arrange
        Animal arg = new();

        // Act
        Action act = () => Guard.Argument(arg).Type(typeof(Dog));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotType_WithType_Pass()
    {
        // Arrange
        object arg = 5;

        // Act
        var act = () => Guard.Argument(arg).NotType(typeof(string));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_WithType_Pass_When_Null()
    {
        // Arrange
        object? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotType(typeof(string));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_WithType_Fail()
    {
        // Arrange
        object arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).NotType(typeof(string));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotType_WithTypedArgument_Pass()
    {
        // Arrange
        Animal arg = new();

        // Act
        var act = () => Guard.Argument(arg).NotType(typeof(Dog));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotType_WithTypedArgument_Fail()
    {
        // Arrange
        Animal arg = new Dog();

        // Act
        Action act = () => Guard.Argument(arg).NotType(typeof(Dog));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Compatible_Pass()
    {
        // Arrange
        Dog arg = new();

        // Act
        var act = () => Guard.Argument(arg).Compatible<Dog, Animal>();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Compatible_Fail_NotAssignable()
    {
        // Arrange
        var arg = new Uri("http://example.com");

        // Act
        Action act = () => Guard.Argument(arg).Compatible<Uri, Dog>();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Compatible_Fail_Null()
    {
        // Arrange
        Dog? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).Compatible<Dog, Animal>();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Type_Throws_When_Type_Null()
    {
        // Arrange
        var arg = new object();

        // Act
        Action act = () => Guard.Argument(arg).Type(type: null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("type");
    }

    [Test]
    public void NotType_Throws_When_Type_Null()
    {
        // Arrange
        var arg = new object();

        // Act
        Action act = () => Guard.Argument(arg).NotType(type: null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("type");
    }

    [Test]
    public void NotCompatible_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).NotCompatible<string, Uri>();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotCompatible_Pass_Null()
    {
        // Arrange
        string? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NotCompatible<string, Uri>();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotCompatible_Fail()
    {
        // Arrange
        Dog arg = new();

        // Act
        Action act = () => Guard.Argument(arg).NotCompatible<Dog, Animal>();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





