using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recursion.Internal;
using Xunit;

namespace Recursion.Tests
{
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

        [Fact]
        public void RecursiveDeclaration()
        {
            var factorial = RecursiveFunction.Create<int, int>(
                (x, fact) => x == 0 ? 1 : x * fact(x - 1));

            Assert.Equal(120, factorial(5));
        }

        [Fact]
        public void Test1()
        {
            var sb = new StringBuilder();

            var function = RecursiveFunction.Create<TreeNode>((node, recurse) =>
            {
                // define the recursive action
                sb.Append(node.Name).Append(' ');
                foreach (var child in node.Children)
                    recurse(child);
            });

            function(_tree);

            Assert.Equal("ted barbie bobbu", sb.ToString().Trim());
        }

        [Fact]
        public void Test2()
        {
            var transform = RecursiveFunction.Create<TreeNode, IntNode>((node, recurse) => new IntNode
            {
                Data = node.Name.Length,
                Children = node.Children.Select(recurse).ToList()
            });

            var intNodes = transform(_tree);

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
