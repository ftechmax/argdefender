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
        var info = new ArgumentInfo<int>(_fixture.Create<int>(), name: null);

        info.Name.ShouldBe("The System.Int32 argument");
    }

    [Test]
    public void Implicit_Conversion_And_ToString_Work()
    {
        var info = new ArgumentInfo<string>("hello", name: "greeting");

        string value = info;
        value.ShouldBe("hello");
        info.ToString().ShouldBe("hello");
    }

    [Test]
    public void ToString_Returns_Empty_For_Null()
    {
        var info = new ArgumentInfo<string?>(null, name: "maybeNull");

        info.ToString().ShouldBe(string.Empty);
    }

    [Test]
    public void DebuggerDisplay_Hides_When_Secure()
    {
        var info = new ArgumentInfo<string>("secret", secure: true, name: "secretArg");
        var property = typeof(ArgumentInfo<string>).GetProperty("DebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance);

        var display = (string?)property?.GetValue(info);

        display.ShouldBe("[SECURE] secretArg: secret");
    }
}
