class Tree
{
    private TreeNode _root { get; set; }
    public Tree(TreeNode root)
    {
        _root = root;
    }

    public bool Insert(int value)
    {
        var newNode = new TreeNode(value);
        if (_root == null)
        {
            _root = newNode;
            return true;
        }

        var result = Find(value, _root, null);
        if (result.Value == value)
            return false;

        if (result.Value > value)
            result.LeftNode = newNode;

        if (result.Value < value)
            result.RightNode = newNode;

        return true;
    }

    public TreeNode Find(int value)
    {
        var findResult = Find(value, _root, null);
        
            if (findResult is not null && findResult.Value == value)
                return findResult;

        return null;
    }

    private TreeNode Find(int value, TreeNode current, TreeNode previous)
    {
        if (current == null) return previous;

        if (current.Value == value) return current;

        if (current.Value < value)
            return Find(value, current.RightNode, current);

        if (current.Value > value)
            return Find(value, current.LeftNode, current);

        return previous;
    }
}


