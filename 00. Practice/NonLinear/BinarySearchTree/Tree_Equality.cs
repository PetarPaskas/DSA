public static class Tree_Equality
{
    public static void Test()
    {
        var tree = new Tree();
        var tree2 = new Tree();
        int[] items = [20, 10, 30, 14, 6, 8, 3, 24, 26];
        int[] items2 = [20, 10, 30, 14, 6, 8, 3, 24];

        foreach (var item in items)
            tree.Insert(item);


        foreach (var item in items2)
            tree2.Insert(item);

        Console.WriteLine(tree.Equals(tree2));
    }
}

public static class TreeExtension
{
    public static bool Equals(this Tree sourceTree, Tree compareTree)
    {
        var x = sourceTree.GetRoot();
        var y = compareTree.GetRoot();

        return Compare(x, y);
    }

    private static bool Compare(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) return true;
        if (root1.Value != root2.Value)
            return false;

        var res1 = Compare(root1.LeftNode, root2.LeftNode);
        var res2 = Compare(root1.RightNode, root2.RightNode);

        if (!res1) return false;

        return res1 && res2;
    }
}
