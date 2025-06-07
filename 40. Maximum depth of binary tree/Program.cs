



int MaxDepth(TreeNode root)
{
    return CalculateDepth(root, 0);
}

int CalculateDepth(TreeNode node, int currentDepth)
{
    if (node == null) return currentDepth;

    var lDepth = CalculateDepth(node.left, currentDepth+1);
    var rDepth = CalculateDepth(node.right, currentDepth+1);

    return Math.Max(lDepth, rDepth);
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}