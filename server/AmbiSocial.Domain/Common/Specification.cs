namespace AmbiSocial.Domain.Common;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class Specification<T>
{
    private static readonly ConcurrentDictionary<string, Func<T, bool>> DelegateCache = new();
    private readonly List<string> cacheKey;

    protected Specification()
        => this.cacheKey = new() { GetType().Name };

    protected virtual bool Include => true;

    public virtual bool IsSatisfiedBy(T value)
    {
        if (!this.Include)
        {
            return true;
        }

        var func = DelegateCache.GetOrAdd(
            string.Join(string.Empty, this.cacheKey),
            _ => this.ToExpression().Compile());

        return func(value);
    }

    public abstract Expression<Func<T, bool>> ToExpression();

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        => specification.Include
            ? specification.ToExpression()
            : _ => true;
}