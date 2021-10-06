using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recursion.Internal;
using Xunit;

namespace Recursion.Tests
{
    public class Recursive<T>
    {

    }

    public class RecursionTests
    {
        private static readonly TreeNode _tree = new()
        {
            Name = "ted",
            Children =
            {
                new TreeNode
                {
                    Name = "barbie"
                },
                new TreeNode
                {
                    Name = "bobbu"
                }
            }
        };

        public void RecursiveDeclaration()
        {
            var fact = new VisitorInternal<int, int>((x, recurse) =>
            {
                if (x == 0)
                    return 1;
                return x * recurse(x - 1);
            });
        }

        [Fact]
        public void Test1()
        {
            var sb = new StringBuilder();

            var visitor = new VisitorInternal<TreeNode>((node, recurse) =>
            {
                // define the recursive action
                sb.Append(node.Name).Append(' ');
                foreach (var child in node.Children)
                    recurse(child);
            });

            visitor.Visit(_tree);

            Assert.Equal("ted barbie bobbu", sb.ToString().Trim());
        }

        [Fact]
        public void Test2()
        {
            var visitor = new VisitorInternal<TreeNode, IntNode>((node, recurse) => new IntNode
            {
                Data = node.Name.Length,
                Children = node.Children.Select(recurse).ToList()
            });

            var intNodes = visitor.Visit(_tree);

            Assert.Equal(3, intNodes.Data);
            Assert.Equal(6, intNodes.Children[0].Data);
            Assert.Equal(5, intNodes.Children[1].Data);
        }
    }

    internal class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode> { };
    }

    internal class IntNode
    {
        public int Data { get; set; }
        public List<IntNode> Children { get; set; } = new List<IntNode> { };
    }
}
