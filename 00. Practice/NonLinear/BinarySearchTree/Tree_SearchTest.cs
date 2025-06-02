public static class Tree_SearchTest
{
    public static void Test()
    {
        var root = new TreeNode(10);
        var firstRight= new TreeNode(17);
        var firstLeft = new TreeNode(6);
        var leafRight = new TreeNode(8);

        root.RightNode = firstRight;
        root.LeftNode = firstLeft;
        root.LeftNode.RightNode = leafRight;

        var tree = new Tree(root);

        var x1 = tree.Find(10);
        Console.WriteLine($"root: {root == x1}");

        var x2 = tree.Find(17);
        Console.WriteLine($"firstRight: {firstRight == x2}");

        var x3 = tree.Find(6);
        Console.WriteLine($"firstLeft: {firstLeft == x3}");

        var x4 = tree.Find(8);
        Console.WriteLine($"leafRight: {leafRight == x4}");

        var x5 = tree.Find(25);
        Console.WriteLine($"Does not exist: {x5 == null}");
    }
}