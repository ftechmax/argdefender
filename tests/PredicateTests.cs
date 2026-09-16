using Shouldly;

namespace ArgDefender.Test;

public class PredicateTests
{
    [Test]
    public void Require_Bool_Pass()
    {
        // Arrange
        var arg = 42;

        // Act
        var act = () => Guard.Argument(arg).Require(true);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Require_Bool_Fail()
    {
        // Arrange
        var arg = 42;

        // Act
        Action act = () => Guard.Argument(arg).Require(false);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Require_Bool_CustomMessage()
    {
        // Arrange
        var arg = 0;

        // Act
        Action act = () => Guard.Argument(arg).Require(false, v => $"Value {v} is invalid");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain("Value 0 is invalid");
    }

    [Test]
    public void Require_Predicate_Pass()
    {
        // Arrange
        var arg = "value";

        // Act
        var act = () => Guard.Argument(arg).Require(v => v!.Length == 5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Require_Predicate_Fail()
    {
        // Arrange
        var arg = "value";

        // Act
        Action act = () => Guard.Argument(arg).Require(v => v!.Length == 1);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Require_Predicate_NullPredicate_Throws()
    {
        // Arrange
        var arg = 10;

        // Act
        Action act = () => Guard.Argument(arg).Require((Func<int, bool>)null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void Require_Predicate_CustomMessage()
    {
        // Arrange
        string? arg = null;

        // Act
        Action act = () => Guard.Argument(arg).Require(v => v is not null, v => "Argument cannot be null");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain("Argument cannot be null");
    }
}
