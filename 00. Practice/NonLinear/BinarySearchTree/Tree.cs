public class Tree
{
    private TreeNode _root { get; set; }
    public Tree(){

    }
    public Tree(TreeNode root)
    {
        _root = root;
    }

    public TreeNode GetRoot() => _root;

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

    public void InOrderTraversal()
    {
        InOrderTraversal(_root);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node == null) return;

        InOrderTraversal(node.LeftNode);
        Console.WriteLine(node.Value);
        InOrderTraversal(node.RightNode);
    }

    public void PreOrderTraversal()
    {
        PreOrderTraversal(_root);
    }
    private void PreOrderTraversal(TreeNode node)
    {
        if (node == null) return;

        Console.WriteLine(node.Value);
        PreOrderTraversal(node.LeftNode);
        PreOrderTraversal(node.RightNode);
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversal(_root);
    }
    private void PostOrderTraversal(TreeNode node)
    {
        if (node == null) return;

        PostOrderTraversal(node.LeftNode);
        PostOrderTraversal(node.RightNode);
        Console.WriteLine(node.Value);

    }

    public void BreadthTraversal()
    {
        BreadthTraversal(_root);
    }

    private void BreadthTraversal(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int limit = queue.Count;
        while (limit > 0) 
        {
            for (int i = 0; i < limit; i++)
            {
                var node = queue.Dequeue();

                if (node == null) continue;

                Console.WriteLine(node.Value);

                queue.Enqueue(node.LeftNode);
                queue.Enqueue(node.RightNode);
            }
            limit = queue.Count;
        }
    } 

    public int GetHeightOfTheTree()
    {
        return GetHeightOfTheTree(_root, 0);
    }

    private int GetHeightOfTheTree(TreeNode node, int height)
    {
        if (node == null) return height-1;

        
        int lh = GetHeightOfTheTree(node.LeftNode, height + 1);
        int rh = GetHeightOfTheTree(node.RightNode, height + 1);

        return lh > rh ? lh : rh;
    }
}


