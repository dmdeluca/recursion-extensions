# recursion-extensions
These are extensions for creating simple recursive visitors. Mainly a for-fun project.

I created this because it allows the developer to create a recursive anonymous function in one line instead of two.

```csharp
// This is the normal way to create a recursive anonymous method.
Func<int,int> fact = null;
fact = x => x == 0 ? 1 : x * fact(x - 1));
```

```csharp
// This is how you'd create it with this library.
var factorial = RecursiveFunction.Create<int, int>((x, fact) => x == 0 ? 1 : x * fact(x - 1));
```

Supposing you have a class that needs to be traversed by a visitor...
```csharp
class TreeNode
{
    public string Name { get; set; }
    public List<TreeNode> Children { get; set; } = new List<TreeNode> { };
}
```
You can create a recursive visitor as follows.
```csharp
var allJeff = RecursiveFunction.Create<TreeNode, bool>((node, recurse) =>
{
    return node.Name.Equals("jeff") && node.Children.All(recurse);
});

var nodes = new TreeNode
{
    Name = "jeff",
    Children = new List<TreeNode>
    {
        new TreeNode { Name = "jeff" },
        new TreeNode { Name = "jeff" }
    }
};

Assert.True(allJeff(nodes));
```
