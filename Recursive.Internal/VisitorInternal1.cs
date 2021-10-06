using System;

namespace Recursion.Internal
{
    public static class RecursiveFunction
    {
        public static Func<TSource,TResult> Create<TSource, TResult>(Func<TSource, Func<TSource, TResult>, TResult> function)
        {
            TResult recurse(TSource a) => function(a, recurse);
            return recurse;
        }

        public static Action<TSource> Create<TSource>(Action<TSource, Action<TSource>> action)
        {
            void recurse(TSource a) => action(a, recurse);
            return recurse;
        }
    }
}
