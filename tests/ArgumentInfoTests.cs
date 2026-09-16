using System.Reflection;
using AutoFixture;
using Shouldly;

namespace ArgDefender.Test;

public class ArgumentInfoTests
{
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [Test]
    public void Name_Uses_Default_When_Missing()
    {
        // Arrange
        var value = _fixture.Create<int>();

        // Act
        var info = new ArgumentInfo<int>(value, name: null);

        // Assert
        info.Name.ShouldBe("The System.Int32 argument");
    }

    [Test]
    public void Implicit_Conversion_And_ToString_Work()
    {
        // Arrange
        var info = new ArgumentInfo<string>("hello", name: "greeting");

        // Act
        string value = info;
        var text = info.ToString();

        // Assert
        value.ShouldBe("hello");
        text.ShouldBe("hello");
    }

    [Test]
    public void ToString_Returns_Empty_For_Null()
    {
        // Arrange
        var info = new ArgumentInfo<string?>(null, name: "maybeNull");

        // Act
        var text = info.ToString();

        // Assert
        text.ShouldBe(string.Empty);
    }

    [Test]
    public void DebuggerDisplay_Hides_When_Secure()
    {
        // Arrange
        var info = new ArgumentInfo<string>("secret", secure: true, name: "secretArg");
        var property = typeof(ArgumentInfo<string>).GetProperty("DebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance);

        // Act
        var display = (string?)property?.GetValue(info);

        // Assert
        display.ShouldBe("[SECURE] secretArg: secret");
    }
}
