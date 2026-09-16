using System.Collections;
using Shouldly;

namespace ArgDefender.Test;

public class EnumerableTests
{
    private sealed record SampleRecord(int Id);

    [Test]
    public void Empty_Pass()
    {
        // Arrange
        var arg = Array.Empty<int>();

        // Act
        var act = () => Guard.Argument(arg).Empty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Pass_Null()
    {
        // Arrange
        List<int>? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Empty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Fail()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).Empty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Pass()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        var act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Fail()
    {
        // Arrange
        var arg = new List<int>();

        // Act
        Action act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Count_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).Count(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Count_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        Action act = () => Guard.Argument(arg).Count(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotCount_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).NotCount(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotCount_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        Action act = () => Guard.Argument(arg).NotCount(3);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MinCount_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).MinCount(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MinCount_Fail()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).MinCount(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MaxCount_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2 };

        // Act
        var act = () => Guard.Argument(arg).MaxCount(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        Action act = () => Guard.Argument(arg).MaxCount(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void CountInRange_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).CountInRange(2, 4);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void CountInRange_Fail_Below()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).CountInRange(2, 4);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void CountInRange_Fail_Above()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        Action act = () => Guard.Argument(arg).CountInRange(2, 4);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Contains_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).Contains(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Contains_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 3 };

        // Act
        Action act = () => Guard.Argument(arg).Contains(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Contains_Pass_NullCollection()
    {
        // Arrange
        List<int>? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Contains(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Contains_Record_Pass_NonGeneric()
    {
        // Arrange
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        // Act
        var act = () => Guard.Argument(arg).Contains(new SampleRecord(1));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Contains_Record_Fail_NonGeneric()
    {
        // Arrange
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        // Act
        Action act = () => Guard.Argument(arg).Contains(new SampleRecord(2));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotContain_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 3 };

        // Act
        var act = () => Guard.Argument(arg).DoesNotContain(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        Action act = () => Guard.Argument(arg).DoesNotContain(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotContain_Record_Pass_NonGeneric()
    {
        // Arrange
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        // Act
        var act = () => Guard.Argument(arg).DoesNotContain(new SampleRecord(2));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Record_Fail_NonGeneric()
    {
        // Arrange
        IEnumerable arg = new ArrayList { new SampleRecord(1) };

        // Act
        Action act = () => Guard.Argument(arg).DoesNotContain(new SampleRecord(1));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Any_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).Any((int v) => v > 2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Any_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2 };

        // Act
        Action act = () => Guard.Argument(arg).Any((int v) => v > 2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Any_Throws_When_Predicate_Null()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).Any((Func<int, bool>)null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void All_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).All((int v) => v > 0);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void All_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, -1 };

        // Act
        Action act = () => Guard.Argument(arg).All((int v) => v > 0);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void All_Throws_When_Predicate_Null()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).All((Func<int, bool>)null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void None_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).None((int v) => v < 0);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void None_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, -1 };

        // Act
        Action act = () => Guard.Argument(arg).None((int v) => v < 0);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void None_Throws_When_Predicate_Null()
    {
        // Arrange
        var arg = new List<int> { 1 };

        // Act
        Action act = () => Guard.Argument(arg).None((Func<int, bool>)null!);

        // Assert
        var exception = act.ShouldThrow<ArgumentNullException>();
        exception.ParamName.ShouldBe("predicate");
    }

    [Test]
    public void AllNotNull_Pass()
    {
        // Arrange
        var arg = new List<string?> { "a", "b" };

        // Act
        var act = () => Guard.Argument(arg).AllNotNull();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void AllNotNull_Fail()
    {
        // Arrange
        var arg = new List<string?> { "a", null };

        // Act
        Action act = () => Guard.Argument(arg).AllNotNull();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void AllNotNull_Pass_NullableStruct()
    {
        // Arrange
        var arg = new List<int?> { 1, 2 };

        // Act
        var act = () => Guard.Argument(arg).AllNotNull();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void AllNotNull_Fail_NullableStruct()
    {
        // Arrange
        var arg = new List<int?> { 1, null };

        // Act
        Action act = () => Guard.Argument(arg).AllNotNull();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NoDuplicates_Pass()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 3 };

        // Act
        var act = () => Guard.Argument(arg).NoDuplicates();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_Fail()
    {
        // Arrange
        var arg = new List<int> { 1, 2, 1 };

        // Act
        Action act = () => Guard.Argument(arg).NoDuplicates();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NoDuplicates_Fail_WithComparer()
    {
        // Arrange
        var arg = new List<string> { "a", "A" };

        // Act
        Action act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InCollection_Pass()
    {
        // Arrange
        var arg = "a";
        var collection = new[] { "a", "b", "c" };

        // Act
        var act = () => Guard.Argument(arg).In(collection);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Fail()
    {
        // Arrange
        var arg = "z";
        var collection = new[] { "a", "b", "c" };

        // Act
        Action act = () => Guard.Argument(arg).In(collection);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotInCollection_Pass()
    {
        // Arrange
        var arg = "z";
        var collection = new[] { "a", "b", "c" };

        // Act
        var act = () => Guard.Argument(arg).NotIn(collection);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotInCollection_Fail()
    {
        // Arrange
        var arg = "b";
        var collection = new[] { "a", "b", "c" };

        // Act
        Action act = () => Guard.Argument(arg).NotIn(collection);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void InCollection_Throws_When_Collection_Null()
    {
        // Arrange
        var arg = "a";

        // Act
        Action act = () => Guard.Argument(arg).In(collection: null!);

        // Assert
        act.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void NotInCollection_Throws_When_Collection_Null()
    {
        // Arrange
        var arg = "a";

        // Act
        Action act = () => Guard.Argument(arg).NotIn(collection: null!);

        // Assert
        act.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void Contains_NonGeneric_Pass_NullCollection()
    {
        // Arrange
        IEnumerable? arg = null;

        // Act
        var act = () => Guard.Argument(arg).Contains(new object());

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_NonGeneric_Pass_NullCollection()
    {
        // Arrange
        IEnumerable? arg = null;

        // Act
        var act = () => Guard.Argument(arg).DoesNotContain(new object());

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotContain_Generic_Pass_NullCollection()
    {
        // Arrange
        List<int>? arg = null;

        // Act
        var act = () => Guard.Argument(arg).DoesNotContain(1);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_WithComparer_Throws_When_Comparer_Null()
    {
        // Arrange
        var arg = new List<string> { "a" };

        // Act
        Action act = () => Guard.Argument(arg).NoDuplicates<List<string>, string>(comparer: null!);

        // Assert
        act.ShouldThrow<ArgumentNullException>().ParamName.ShouldBe("comparer");
    }

    [Test]
    public void NoDuplicates_WithComparer_Pass_When_NullCollection()
    {
        // Arrange
        List<string>? arg = null;

        // Act
        var act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NoDuplicates_WithComparer_Pass()
    {
        // Arrange
        var arg = new List<string> { "a", "b" };

        // Act
        var act = () => Guard.Argument(arg).NoDuplicates(StringComparer.OrdinalIgnoreCase);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Pass_When_Value_Null()
    {
        // Arrange
        string? arg = null;
        var collection = new[] { "a", "b" };

        // Act
        var act = () => Guard.Argument(arg).In(collection);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotInCollection_Pass_When_Value_Null()
    {
        // Arrange
        string? arg = null;
        var collection = new[] { "a", "b" };

        // Act
        var act = () => Guard.Argument(arg).NotIn(collection);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void InCollection_Fail_With_Ellipsis()
    {
        // Arrange
        var arg = "z";
        var collection = new[] { "a", "b", "c", "d", "e", "f", "g" };

        // Act
        Action act = () => Guard.Argument(arg).In(collection);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void Collection_Guards_Pass_When_Null()
    {
        // Arrange
        List<int>? arg = null;

        // Act
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

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Count_NonCollection_Pass()
    {
        // Arrange
        IEnumerable<int> arg = YieldSequence(3);

        // Act
        var act = () => Guard.Argument(arg).Count(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_NonCollection_Pass()
    {
        // Arrange
        IEnumerable<int> arg = YieldSequence(2);

        // Act
        var act = () => Guard.Argument(arg).MaxCount(3);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MaxCount_NonCollection_Fail()
    {
        // Arrange
        IEnumerable<int> arg = YieldSequence(5);

        // Act
        Action act = () => Guard.Argument(arg).MaxCount(3);

        // Assert
        act.ShouldThrow<ArgumentException>();
    }

    [Test]
    public void CountInRange_NonCollection_Pass()
    {
        // Arrange
        IEnumerable<int> arg = YieldSequence(3);

        // Act
        var act = () => Guard.Argument(arg).CountInRange(2, 4);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void CountInRange_NonCollection_Fail()
    {
        // Arrange
        IEnumerable<int> arg = YieldSequence(5);

        // Act
        Action act = () => Guard.Argument(arg).CountInRange(1, 4);

        // Assert
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





