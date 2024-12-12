namespace AdventOfCode2024;

public static class Extensions
{
    public static TResult Lambda<T1, T2, TResult>(this Tuple<T1, T2> source, Func<T1, T2, TResult> func)
    {
        return func(source.Item1, source.Item2);
    }
    
    /// <summary>
    /// Apply <paramref name="func"/> to <paramref name="source"/> and return the result.
    /// </summary>
    /// <param name="source">
    /// The value to apply <paramref name="func"/> to.
    /// </param>
    /// <param name="func">
    /// The function to apply.
    /// </param>
    /// <typeparam name="TSource">
    /// The type of the source value
    /// </typeparam>
    /// <typeparam name="TResult">
    /// The type of the result value
    /// </typeparam>
    /// <returns>
    /// The result of <paramref name="func"/>
    /// </returns>
    public static TResult Lambda<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
    {
        return func(source);
    }

    /// <summary>
    /// Apply <paramref name="action"/> to <paramref name="source"/>.
    /// </summary>
    /// <param name="source">
    /// The value to apply <paramref name="action"/> to.
    /// </param>
    /// <param name="action">
    /// The action to apply
    /// </param>
    /// <typeparam name="TSource">
    /// The type of the source value
    /// </typeparam>
    public static void Lambda<TSource>(this TSource source, Action<TSource> action)
    {
        action(source);
    }
    
    /// <summary>
    /// Apply a <see cref="func"/> to <see cref="source"/> and return <see cref="source"/>.
    /// </summary>
    /// <param name="source">The input object</param>
    /// <param name="func">The function to apply to <paramref name="source"/></param>
    /// <typeparam name="TSource">The input type</typeparam>
    /// <typeparam name="TResult">The type returned by <paramref name="func"/></typeparam>
    /// <returns>
    ///     <paramref name="source"/>
    /// </returns>
    public static TSource Mutate<TSource, TResult>(this TSource source, Func<TSource, TResult> func)
    {
        func(source);
        return source;
    }

    /// <summary>
    /// Apply an <see cref="Action"/> to <see cref="source"/> and return <see cref="source"/>.
    /// </summary>
    /// <param name="source">The input object</param>
    /// <param name="action">The action to apply to <paramref name="source"/></param>
    /// <typeparam name="TSource">The input type</typeparam>
    /// <returns>
    ///     <paramref name="source"/>
    /// </returns>
    public static TSource Mutate<TSource>(this TSource source, Action<TSource> action)
    {
        action(source);
        return source;
    }

    /// <summary>
    /// Apply an <see cref="Action"/> and return <see cref="source"/>.
    /// </summary>
    /// <param name="source">The input object</param>
    /// <param name="action">The action to apply </param>
    /// <typeparam name="TSource">The input type</typeparam>
    /// <returns>
    ///     <paramref name="source"/>
    /// </returns>
    public static TSource Mutate<TSource>(this TSource source, Action action)
    {
        action();
        return source;
    }

    /// <summary>
    /// Applies <paramref name="action"/> to each element of <paramref name="source"/>, and then returns <paramref name="source"/>.
    /// Note that this function enumerates <paramref name="source"/>.
    /// For a version of this function that utilizes deferred execution, see <see cref="ForEachDeferred{TSource}"/>
    /// </summary>
    ///
    /// <remarks>
    /// Take this into consideration when implementing: https://docs.microsoft.com/en-us/archive/blogs/ericlippert/foreach-vs-foreach
    /// It may be best to do away with this altogether
    /// </remarks>
    ///
    /// <param name="source">
    /// An <see cref="IEnumerable{TSource}"/> whose elements will have <paramref name="action"/> applied.
    /// </param>
    ///
    /// <param name="action">
    /// The <see cref="Action"/> to apply to each element of <paramref name="source"/>
    /// </param>
    ///
    /// <typeparam name="TSource">
    /// The type of the elements of <paramref name="source"/>.
    /// </typeparam>
    ///
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> whose elements have had <paramref name="action"/> applied to each for its side effects.
    /// </returns>
    public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (var item in source)
        {
            action(item);
        }

        return source;
    }

    /// <summary>
    /// Applies <paramref name="func"/> to each element of <paramref name="source"/>, and then returns <paramref name="source"/>. The return type
    /// of <paramref name="func"/> is completely ignored.
    /// Note that this function enumerates <paramref name="source"/>.
    /// For a version of this function that utilizes deferred execution, see <see cref="ForEachDeferred{TSource, TResult}"/>
    /// </summary>
    ///
    /// <param name="source">
    /// An <see cref="IEnumerable{TSource}"/> whose elements will have <paramref name="func"/> applied.
    /// </param>
    ///
    /// <param name="func">
    /// The <see cref="Func{TSource, TResult}"/> to apply to each element of <paramref name="source"/>.
    /// </param>
    ///
    /// <typeparam name="TSource">
    /// The type of the elements of <paramref name="source"/>.
    /// </typeparam>
    ///
    /// <typeparam name="TResult">
    /// The return type of <paramref name="func"/>, the type does not matter as this <see cref="Func{TSource, TResult}"/> is applied for it's side
    /// effects, and not the return value.
    /// </typeparam>
    ///
    /// <returns>
    /// An <see cref="IEnumerable{TSource}"/> whose elements have had <paramref name="func"/> applied to each for its side effects.
    /// </returns>
    public static IEnumerable<TSource> ForEach<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
    {
        foreach (var item in source)
        {
            func(item);
        }

        return source;
    }

    public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        var chunk = new List<TSource>();
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return chunk;
                chunk = new List<TSource>();
            }
            else
            {
                chunk.Add(item);
            }
        }

        if (chunk.Any())
        {
            yield return chunk;
        }
    }

    public static IEnumerable<IEnumerable<TSource>> ChunkBy<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        var chunk = new List<TSource>();
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return chunk;
                chunk = new List<TSource>();
            }
            else
            {
                chunk.Add(item);
            }
        }

        if (chunk.Any())
        {
            yield return chunk;
        }
    }
    
    public static IEnumerable<IEnumerable<TSource>> Transpose<TSource>(this IEnumerable<IEnumerable<TSource>> source)
    {
        var result = new List<List<TSource>>();

        foreach (var row in source)
        {
            var colIndex = 0;
            foreach (var column in row)
            {
                if(result.Count <= colIndex){
                    result.Add(new());
                }
                result[colIndex].Add(column);
                colIndex++;
            }
        }

        return result;
    }

    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static long Gcd(long left, long right)
    {
        while (right != 0)
        {
            long temp = left % right;
            left = right;
            right = temp;
        }

        return left;
    }

    public static long Gcd(IEnumerable<long> numbers) => numbers.Aggregate(Gcd);
}