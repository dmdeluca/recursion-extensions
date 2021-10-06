using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Recursion.Internal
{
    internal sealed class Visitor<TSource> : IVisitor<TSource>
    {
        private readonly Action<TSource> _recurse = null;

        public Visitor(Action<TSource, Action<TSource>> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _recurse = (a) => action(a, _recurse);
        }

        public void Visit(TSource source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _recurse(source);
        }
    }
}
