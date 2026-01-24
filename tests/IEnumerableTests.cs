using System.Collections;
using Shouldly;

namespace ArgDefender.Test;

public class IEnumerableTests
{
    private sealed record SampleRecord(int Id);

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
    public void Contains_Record_Pass_NonGeneric()
    {
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        var act = () => Guard.Argument(arg).Contains(new SampleRecord(1));

        act.ShouldNotThrow();
    }

    [Test]
    public void Contains_Record_Fail_NonGeneric()
    {
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        Action act = () => Guard.Argument(arg).Contains(new SampleRecord(2));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
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
    public void DoesNotContain_Record_Pass_NonGeneric()
    {
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        var act = () => Guard.Argument(arg).DoesNotContain(new SampleRecord(2));

        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Record_Fail_NonGeneric()
    {
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        Action act = () => Guard.Argument(arg).DoesNotContain(new SampleRecord(1));

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Any_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).Any((int v) => v > 2);

        act.ShouldNotThrow();
    }

    [Test]
    public void Any_Fail()
    {
        var arg = new List<int> { 1, 2 };

        Action act = () => Guard.Argument(arg).Any((int v) => v > 2);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Any_Throws_When_Predicate_Null()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).Any((Func<int, bool>)null!);

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void All_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).All((int v) => v > 0);

        act.ShouldNotThrow();
    }

    [Test]
    public void All_Fail()
    {
        var arg = new List<int> { 1, -1 };

        Action act = () => Guard.Argument(arg).All((int v) => v > 0);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void All_Throws_When_Predicate_Null()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).All((Func<int, bool>)null!);

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void None_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).None((int v) => v < 0);

        act.ShouldNotThrow();
    }

    [Test]
    public void None_Fail()
    {
        var arg = new List<int> { 1, -1 };

        Action act = () => Guard.Argument(arg).None((int v) => v < 0);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void None_Throws_When_Predicate_Null()
    {
        var arg = new List<int> { 1 };

        Action act = () => Guard.Argument(arg).None((Func<int, bool>)null!);

        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void AllNotNull_Pass()
    {
        var arg = new List<string?> { "a", "b" };

        var act = () => Guard.Argument(arg).AllNotNull();

        act.ShouldNotThrow();
    }

    [Test]
    public void AllNotNull_Fail()
    {
        var arg = new List<string?> { "a", null };

        Action act = () => Guard.Argument(arg).AllNotNull();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void AllNotNull_Pass_NullableStruct()
    {
        var arg = new List<int?> { 1, 2 };

        var act = () => Guard.Argument(arg).AllNotNull();

        act.ShouldNotThrow();
    }

    [Test]
    public void AllNotNull_Fail_NullableStruct()
    {
        var arg = new List<int?> { 1, null };

        Action act = () => Guard.Argument(arg).AllNotNull();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NoDuplicates_Pass()
    {
        var arg = new List<int> { 1, 2, 3 };

        var act = () => Guard.Argument(arg).NoDuplicates();

        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_Fail()
    {
        var arg = new List<int> { 1, 2, 1 };

        Action act = () => Guard.Argument(arg).NoDuplicates();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NoDuplicates_Fail_WithComparer()
    {
        var arg = new List<string> { "a", "A" };

        Action act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

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

    [Test]
    public void Contains_NonGeneric_Pass_NullCollection()
    {
        IEnumerable? arg = null;

        var act = () => Guard.Argument(arg).Contains(new object());

        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_NonGeneric_Pass_NullCollection()
    {
        IEnumerable? arg = null;

        var act = () => Guard.Argument(arg).DoesNotContain(new object());

        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Generic_Pass_NullCollection()
    {
        List<int>? arg = null;

        var act = () => Guard.Argument(arg).DoesNotContain(1);

        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_WithComparer_Throws_When_Comparer_Null()
    {
        var arg = new List<string> { "a" };

        Action act = () => Guard.Argument(arg).NoDuplicates<List<string>, string>(comparer: null!);

        act.ShouldThrow<ArgumentNullException>().ParamName.ShouldBe("comparer");
    }

    [Test]
    public void NoDuplicates_WithComparer_Pass_When_NullCollection()
    {
        List<string>? arg = null;

        var act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_WithComparer_Pass()
    {
        var arg = new List<string> { "a", "b" };

        var act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Pass_When_Value_Null()
    {
        string? arg = null;
        var collection = new[] { "a", "b" };

        var act = () => Guard.Argument(arg).In(collection);

        act.ShouldNotThrow();
    }

    [Test]
    public void NotInCollection_Pass_When_Value_Null()
    {
        string? arg = null;
        var collection = new[] { "a", "b" };

        var act = () => Guard.Argument(arg).NotIn(collection);

        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Fail_With_Ellipsis()
    {
        var arg = "z";
        var collection = new[] { "a", "b", "c", "d", "e", "f", "g" };

        Action act = () => Guard.Argument(arg).In(collection);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Collection_Guards_Pass_When_Null()
    {
        List<int>? arg = null;

        var act = () =>
        {
            Guard.Argument(arg).NotEmpty();
            Guard.Argument(arg).Count(1);
            Guard.Argument(arg).NotCount(0);
            Guard.Argument(arg).MinCount(1);
            Guard.Argument(arg).MaxCount(1);
            Guard.Argument(arg).CountInRange(0, 1);
            Guard.Argument(arg).Any<List<int>, int>(v => v > 0);
            Guard.Argument(arg).All<List<int>, int>(v => v > 0);
            Guard.Argument(arg).None<List<int>, int>(v => v < 0);
            Guard.Argument(arg).AllNotNull();
            Guard.Argument(arg).NoDuplicates();
        };

        act.ShouldNotThrow();
    }

    [Test]
    public void Count_NonCollection_Pass()
    {
        IEnumerable<int> arg = YieldSequence(3);

        var act = () => Guard.Argument(arg).Count(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_NonCollection_Pass()
    {
        IEnumerable<int> arg = YieldSequence(2);

        var act = () => Guard.Argument(arg).MaxCount(3);

        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_NonCollection_Fail()
    {
        IEnumerable<int> arg = YieldSequence(5);

        Action act = () => Guard.Argument(arg).MaxCount(3);

        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void CountInRange_NonCollection_Pass()
    {
        IEnumerable<int> arg = YieldSequence(3);

        var act = () => Guard.Argument(arg).CountInRange(2, 4);

        act.ShouldNotThrow();
    }

    [Test]
    public void CountInRange_NonCollection_Fail()
    {
        IEnumerable<int> arg = YieldSequence(5);

        Action act = () => Guard.Argument(arg).CountInRange(1, 4);

        act.ShouldThrow<ArgumentException>();
    }

    private static IEnumerable<int> YieldSequence(int count)
    {
        for (var i = 0; i < count; i++)
        {
            yield return i;
        }
    }
}





