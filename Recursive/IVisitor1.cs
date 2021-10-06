namespace Recursion
{
    /// <summary>
    /// A visitor that applies a function to a <typeparamref name="TSource"/> node and returns the transformed <typeparamref name="TResult"/> node.
    /// </summary>
    /// <typeparam name="TSource">The type of the source node.</typeparam>
    /// <typeparam name="TResult">The type of the result node</typeparam>
    public interface IVisitor<TSource, TResult>
    {
        /// <summary>
        /// Applies the visit function to the <paramref name="source"/> node
        /// </summary>
        /// <param name="source">The source node to visit</param>
        /// <returns>A transformed node.</returns>
        TResult Visit(TSource source);
    }
}