using Shouldly;

namespace ArgDefender.Test;

public class IEnumerableTests
{
    [Test]
    public void Empty_Pass()
    {
        var arg = Array.Empty<int>();

        var act = () => Guard.Argument(arg).Empty();

        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Pass_Null()
    {
        List<int>? arg = null;

        var act = () => Guard.Argument(arg).Empty();

        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Fail()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).Empty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Pass()
    {
        var arg = new List<int> { 1 };

        var act = () => Guard.Argument(arg).NotEmpty();

        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Fail()
    {
        var arg = new List<int>();

        Action act = () => Guard.Argument(arg).NotEmpty();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Count_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).Count(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void Count_Fail()
    {
        var arg = new List<int> { 1, 2, 3 };

        Action act = () => Guard.Argument(arg).Count(2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotCount_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).NotCount(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotCount_Fail()
    {
        var arg = new List<int> { 1, 2, 3 };

        Action act = () => Guard.Argument(arg).NotCount(3);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MinCount_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).MinCount(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void MinCount_Fail()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).MinCount(2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MaxCount_Pass()
    {
        var arg = new List<int> { 1, 2 };

        var act = () => Guard.Argument(arg).MaxCount(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_Fail()
    {
        var arg = new List<int> { 1, 2, 3 };

        Action act = () => Guard.Argument(arg).MaxCount(2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void CountInRange_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).CountInRange(2, 4);

        act.ShouldNotThrow();
    }

    [Test]
    public void CountInRange_Fail_Below()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).CountInRange(2, 4);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void CountInRange_Fail_Above()
    {
        var arg = new List<int> { 1, 2, 3, 4, 5 };

        Action act = () => Guard.Argument(arg).CountInRange(2, 4);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Contains_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).Contains(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void Contains_Fail()
    {
        var arg = new List<int> { 1, 3 };

        Action act = () => Guard.Argument(arg).Contains(2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Contains_Pass_NullCollection()
    {
        List<int>? arg = null;

        var act = () => Guard.Argument(arg).Contains(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Pass()
    {
        var arg = new List<int> { 1, 3 };

        var act = () => Guard.Argument(arg).DoesNotContain(2);

        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Fail()
    {
        var arg = new List<int> { 1, 2, 3 };

        Action act = () => Guard.Argument(arg).DoesNotContain(2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InCollection_Pass()
    {
        var arg = "a";
        var collection = new[] { "a", "b", "c" };

        var act = () => Guard.Argument(arg).In(collection);

        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Fail()
    {
        var arg = "z";
        var collection = new[] { "a", "b", "c" };

        Action act = () => Guard.Argument(arg).In(collection);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotInCollection_Pass()
    {
        var arg = "z";
        var collection = new[] { "a", "b", "c" };

        var act = () => Guard.Argument(arg).NotIn(collection);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInCollection_Fail()
    {
        var arg = "b";
        var collection = new[] { "a", "b", "c" };

        Action act = () => Guard.Argument(arg).NotIn(collection);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InCollection_Throws_When_Collection_Null()
    {
        var arg = "a";

        Action act = () => Guard.Argument(arg).In(collection: null!);

        act.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void NotInCollection_Throws_When_Collection_Null()
    {
        var arg = "a";

        Action act = () => Guard.Argument(arg).NotIn(collection: null!);

        act.ShouldThrow<ArgumentNullException>();
    }
}





