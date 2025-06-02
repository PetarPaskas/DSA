using System;

public static class Tree_InsertTest
{
    public static void Test()
    {
        var root = new TreeNode(10);
        var firstRight = new TreeNode(17);
        var firstLeft = new TreeNode(6);
        var leafRight = new TreeNode(8);

        root.RightNode = firstRight;
        root.LeftNode = firstLeft;
        root.LeftNode.RightNode = leafRight;

        var tree = new Tree(root);

        Console.WriteLine($"Cannot insert: {tree.Insert(17) == false}");
        Console.WriteLine($"Can insert: {tree.Insert(22) == true}");
        Console.WriteLine("New value exists: " + tree.Find(22) != null);
    }
}