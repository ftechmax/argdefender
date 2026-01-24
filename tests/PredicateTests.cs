using Shouldly;

namespace ArgDefender.Test;

public class PredicateTests
{
    [Test]
    public void Require_Bool_Pass()
    {
        var arg = 42;

        var act = () => Guard.Argument(arg).Require(true);

        act.ShouldNotThrow();
    }

    [Test]
    public void Require_Bool_Fail()
    {
        var arg = 42;

        Action act = () => Guard.Argument(arg).Require(false);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Require_Bool_CustomMessage()
    {
        var arg = 0;

        Action act = () => Guard.Argument(arg).Require(false, v => $"Value {v} is invalid");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain("Value 0 is invalid");
    }

    [Test]
    public void Require_Predicate_Pass()
    {
        var arg = "value";

        var act = () => Guard.Argument(arg).Require(v => v!.Length == 5);

        act.ShouldNotThrow();
    }

    [Test]
    public void Require_Predicate_Fail()
    {
        var arg = "value";

        Action act = () => Guard.Argument(arg).Require(v => v!.Length == 1);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Require_Predicate_NullPredicate_Throws()
    {
        var arg = 10;

        Action act = () => Guard.Argument(arg).Require((Func<int, bool>)null!);

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void Require_Predicate_CustomMessage()
    {
        string? arg = null;

        Action act = () => Guard.Argument(arg).Require(v => v is not null, v => "Argument cannot be null");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain("Argument cannot be null");
    }
}
