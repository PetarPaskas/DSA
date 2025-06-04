

public static class Tree_CheckIsBstTree
{
    public static void Test()
    {
        var root = new TreeNode(10);
        var firstRight = new TreeNode(11);
        var firstLeft = new TreeNode(6);
        var leafRight = new TreeNode(7);

        root.RightNode = firstRight;
        root.LeftNode = firstLeft;
        root.LeftNode.RightNode = leafRight;

        var tree = new Tree(root);

        Console.WriteLine(tree.IsBst());
    }

    public static bool IsBst(this Tree tree)
    {
        return IsBstTree(tree.GetRoot(), int.MinValue, int.MaxValue);
    }

    private static bool IsBstTree(TreeNode node, int min, int max) 
    {
        if (node == null) return true;

        bool nodeValueInLimitRange = node.Value > min && node.Value < max;
        if (!nodeValueInLimitRange)
            return false;

        bool l = IsBstTree(node.LeftNode, min, node.Value);
        bool r = IsBstTree(node.RightNode, node.Value, max);

        return l && r;
    }
}

