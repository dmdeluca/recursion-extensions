using System;

namespace Recursion.Internal
{
    public sealed class VisitorInternal<TSource, TResult>
    {
        private readonly Func<TSource, TResult> _recurse = null;

        public VisitorInternal(Func<TSource, Func<TSource, TResult>, TResult> function)
        {
            if (function is null)
            {
                throw new ArgumentNullException(nameof(function));
            }

            _recurse = a => function(a, _recurse);
        }

        public TResult Visit(TSource source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return _recurse(source);
        }
    }
}
