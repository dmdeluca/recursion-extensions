namespace Recursion
{
    /// <summary>
    /// A visitor that executes a function on a node.
    /// </summary>
    /// <typeparam name="TSource">The type of the source node.</typeparam>
    public interface IVisitor<TSource>
    {
        /// <summary>
        /// Executes an action on the source node.
        /// </summary>
        /// <param name="source"></param>
        void Visit(TSource source);
    }

    public static class Visitor
    {
        public IVisitor<TSource> Create<TSource>
    }
}