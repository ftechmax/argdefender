using System.Collections;
using System.Runtime.CompilerServices;

namespace ArgDefender;

public static partial class Guard
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> Empty<TCollection>(
        in this ArgumentInfo<TCollection> argument, Func<TCollection, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null || !HasAny(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.CollectionEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> NotEmpty<TCollection>(
        in this ArgumentInfo<TCollection> argument, Func<TCollection, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        if (HasAny(value))
        {
            return ref argument;
        }

        var m = message?.Invoke(value) ?? Messages.CollectionNotEmpty(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> Count<TCollection>(
        in this ArgumentInfo<TCollection> argument, int count, Func<TCollection, int, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var actual = TryGetCount(value, out var knownCount) ? knownCount : CountAll(value);
        if (actual == count)
        {
            return ref argument;
        }

        var m = message?.Invoke(value, count) ?? Messages.CollectionCount(argument, count);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> NotCount<TCollection>(
        in this ArgumentInfo<TCollection> argument, int count, Func<TCollection, int, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var actual = TryGetCount(value, out var knownCount) ? knownCount : CountAll(value);
        if (actual != count)
        {
            return ref argument;
        }

        var m = message?.Invoke(value, count) ?? Messages.CollectionNotCount(argument, count);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> MinCount<TCollection>(
        in this ArgumentInfo<TCollection> argument, int minCount, Func<TCollection, int, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        if (TryGetCount(value, out var knownCount) ? knownCount >= minCount : CountUpTo(value, minCount) >= minCount)
        {
            return ref argument;
        }

        var m = message?.Invoke(value, minCount) ?? Messages.CollectionMinCount(argument, minCount);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> MaxCount<TCollection>(
        in this ArgumentInfo<TCollection> argument, int maxCount, Func<TCollection, int, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        if (TryGetCount(value, out var knownCount) ? knownCount <= maxCount : CountUpTo(value, maxCount) <= maxCount)
        {
            return ref argument;
        }

        var m = message?.Invoke(value, maxCount) ?? Messages.CollectionMaxCount(argument, maxCount);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> CountInRange<TCollection>(
        in this ArgumentInfo<TCollection> argument, int minCount, int maxCount, Func<TCollection, int, int, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var withinRange = TryGetCount(value, out var knownCount)
            ? knownCount >= minCount && knownCount <= maxCount
            : CountInRangeInternal(value, minCount, maxCount);

        if (withinRange)
        {
            return ref argument;
        }

        var m = message?.Invoke(value, minCount, maxCount) ?? Messages.CollectionCountInRange(argument, minCount, maxCount);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> Contains<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument, TItem item, Func<TCollection, TItem, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<TItem>.Default;
        using var enumerator = value.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (comparer.Equals(enumerator.Current, item))
            {
                return ref argument;
            }
        }

        var m = message?.Invoke(value, item) ?? Messages.CollectionContains(argument, item);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> Contains<TCollection>(
        in this ArgumentInfo<TCollection> argument, object? item, Func<TCollection, object?, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<object?>.Default;
        var enumerator = value.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                if (comparer.Equals(enumerator.Current, item))
                {
                    return ref argument;
                }
            }
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }

        var m = message?.Invoke(value, item) ?? Messages.CollectionContains(argument, item);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> DoesNotContain<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument, TItem item, Func<TCollection, TItem, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<TItem>.Default;
        using var enumerator = value.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (comparer.Equals(enumerator.Current, item))
            {
                var m = message?.Invoke(value, item) ?? Messages.CollectionDoesNotContain(argument, item);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> DoesNotContain<TCollection>(
        in this ArgumentInfo<TCollection> argument, object? item, Func<TCollection, object?, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<object?>.Default;
        var enumerator = value.GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                if (comparer.Equals(enumerator.Current, item))
                {
                    var m = message?.Invoke(value, item) ?? Messages.CollectionDoesNotContain(argument, item);
                    throw new ArgumentException(m, argument.Name);
                }
            }
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> Any<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument,
        Func<TItem, bool> predicate,
        Func<TCollection, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        foreach (var item in value)
        {
            if (predicate(item))
            {
                return ref argument;
            }
        }

        var m = message?.Invoke(value) ?? Messages.CollectionAny(argument);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> All<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument,
        Func<TItem, bool> predicate,
        Func<TCollection, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        foreach (var item in value)
        {
            if (!predicate(item))
            {
                var m = message?.Invoke(value) ?? Messages.CollectionAll(argument);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> None<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument,
        Func<TItem, bool> predicate,
        Func<TCollection, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        foreach (var item in value)
        {
            if (predicate(item))
            {
                var m = message?.Invoke(value) ?? Messages.CollectionNone(argument);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> AllNotNull<TCollection>(
        in this ArgumentInfo<TCollection> argument, Func<TCollection, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        foreach (var item in value)
        {
            if (item is null)
            {
                var m = message?.Invoke(value) ?? Messages.CollectionAllNotNull(argument);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> NoDuplicates<TCollection>(
        in this ArgumentInfo<TCollection> argument, Func<TCollection, string>? message = null)
        where TCollection : IEnumerable
    {
        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var set = new HashSet<object?>();
        foreach (var item in value)
        {
            if (!set.Add(item))
            {
                var m = message?.Invoke(value) ?? Messages.CollectionNoDuplicates(argument);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<TCollection> NoDuplicates<TCollection, TItem>(
        in this ArgumentInfo<TCollection> argument,
        IEqualityComparer<TItem> comparer,
        Func<TCollection, string>? message = null)
        where TCollection : IEnumerable<TItem>
    {
        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }

        var value = argument.Value;
        if (value == null)
        {
            return ref argument;
        }

        var set = new HashSet<TItem>(comparer);
        foreach (var item in value)
        {
            if (!set.Add(item))
            {
                var m = message?.Invoke(value) ?? Messages.CollectionNoDuplicates(argument);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> In<T>(
        in this ArgumentInfo<T> argument, IEnumerable collection, Func<T, IEnumerable, string>? message = null)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (argument.Value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<T>.Default;
        var snapshot = new List<object?>(6);
        foreach (var item in collection)
        {
            if (snapshot.Count < 6)
            {
                snapshot.Add(item);
            }

            if (item is T candidate && comparer.Equals(argument.Value, candidate))
            {
                return ref argument;
            }
        }

        var itemsForMessage = (IEnumerable)snapshot;
        var m = message?.Invoke(argument.Value, itemsForMessage) ?? Messages.InCollection(argument, itemsForMessage);
        throw new ArgumentException(m, argument.Name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly ArgumentInfo<T> NotIn<T>(
        in this ArgumentInfo<T> argument, IEnumerable collection, Func<T, IEnumerable, string>? message = null)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (argument.Value == null)
        {
            return ref argument;
        }

        var comparer = EqualityComparer<T>.Default;
        var snapshot = new List<object?>(6);
        foreach (var item in collection)
        {
            if (snapshot.Count < 6)
            {
                snapshot.Add(item);
            }

            if (item is T candidate && comparer.Equals(argument.Value, candidate))
            {
                var itemsForMessage = (IEnumerable)snapshot;
                var m = message?.Invoke(argument.Value, itemsForMessage) ?? Messages.NotInCollection(argument, itemsForMessage);
                throw new ArgumentException(m, argument.Name);
            }
        }

        return ref argument;
    }

    private static bool HasAny(IEnumerable collection)
    {
        var enumerator = collection.GetEnumerator();
        try
        {
            return enumerator.MoveNext();
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }
    }

    private static bool TryGetCount(IEnumerable collection, out int count)
    {
        if (collection is ICollection col)
        {
            count = col.Count;
            return true;
        }

        count = 0;
        return false;
    }

    private static int CountAll(IEnumerable collection)
    {
        var enumerator = collection.GetEnumerator();
        var count = 0;
        try
        {
            while (enumerator.MoveNext())
            {
                count++;
            }
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }

        return count;
    }

    private static int CountUpTo(IEnumerable collection, int threshold)
    {
        var enumerator = collection.GetEnumerator();
        var count = 0;
        try
        {
            while (enumerator.MoveNext())
            {
                count++;
                if (count > threshold)
                {
                    break;
                }
            }
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }

        return count;
    }

    private static bool CountInRangeInternal(IEnumerable collection, int minCount, int maxCount)
    {
        var enumerator = collection.GetEnumerator();
        var count = 0;
        try
        {
            while (enumerator.MoveNext())
            {
                count++;
                if (count > maxCount)
                {
                    return false;
                }
            }
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }

        return count >= minCount;
    }
}
