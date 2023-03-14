namespace AmbiSocial.Domain.Common;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class Specification<T>
{
    private static readonly ConcurrentDictionary<string, Func<T, bool>> delegateCache;
    private readonly List<string> cacheKey;

    protected Specification()
    {
        delegateCache = new();
        cacheKey = new() { GetType().Name };
    }

    protected virtual bool Include => true;

    public virtual bool IsSatisfiedBy(T value)
    {
        if (!this.Include)
        {
            return true;
        }

        var func = delegateCache.GetOrAdd(
            string.Join(string.Empty, cacheKey),
            _ => ToExpression().Compile());

        return func(value);
    }

    public abstract Expression<Func<T, bool>> ToExpression();

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        => specification.Include
            ? specification.ToExpression()
            : value => true;
}