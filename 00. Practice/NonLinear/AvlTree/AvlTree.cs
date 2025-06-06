using System.Xml.Linq;

namespace AvlTree;

public class AvlTree
{
    public TreeNode Root { get; set; }
    public AvlTree()
    {
        
    }
    public AvlTree(TreeNode root)
    {
        Root = root;
    }

    public void Insert(int value)
    {
       var newNode = new TreeNode(value);
    }

    private void Add(TreeNode node)
    {
        if (Root == null)
        {
            Root = node;
            return;
        }

        Add(Root, node);
    }

    private void Add(TreeNode current, TreeNode node)
    {
        if(current.Value < node.Value)
        {
            if(current.RightNode == null)
            {
                current.RightNode = node;
            }
            else
            {
                Add(current.RightNode, node);
            }
        }

        if(current.Value > node.Value)
        {
            if(current.LeftNode == null)
            {
                current.LeftNode = node;
            }
            else
            {
                Add(current.LeftNode, node);
            }
        }

        return;
    }

    private int BalanceFactor(TreeNode node)
    {
        int leftHeight = node.LeftNode == null ? 0 : node.LeftNode.Height+1;
        int rightHeight = node.RightNode == null ? 0 : node.RightNode.Height+1;

        return leftHeight - rightHeight;
    }

    private void Rebalance()
    {
        TreeNode current = Root;
        int balanceFactor = BalanceFactor(current);

        bool isLeftHeavy = balanceFactor > 1;
        bool isRightHeavy = balanceFactor < -1;

        if (isLeftHeavy)                                                                                                             
        {                                                                                                                        //     O
            int leftNodeBalance = BalanceFactor(current.LeftNode);                                                              //    /
            bool isRightNodeHeavy = leftNodeBalance < 0;    //ako ide O-O-O u levo, onda ce na sledecem node balance biti 1. Ako ide O   <- tu ce biti -1 i znaci da ide left right rotation
            if (isRightNodeHeavy)                                                                                             //      \
            {                                                                                                                 //       O
                LeftRotation(current); //do left right rotation
            }
            RightRotation(current); //do right rotation on node

        }

        if (isRightHeavy)
        {                                                                                                                        //    O
            int rightNodeBalance = BalanceFactor(current.RightNode);                                                             //     \
            bool isLeftNodeHeavy = rightNodeBalance > 0;    //ako ide O-O-O u desno, onda ce na sledecem node balance biti 1. Ako ide    O   <- tu ce biti 1 i znaci da ide left right rotation
            if (isLeftNodeHeavy)                                                                                             //         /
            {                                                                                                                 //       O
                RightRotation(current); //do right left rotation
            }
            LeftRotation(current); //do left rotation on node
        }
        //if none, go to next
    }

    private TreeNode LeftRotation(TreeNode node)
    {
        var newRoot = node.RightNode;
        var currentLeftNodeOnNewRoot = newRoot.LeftNode;

        newRoot.LeftNode = node;
        node.RightNode = currentLeftNodeOnNewRoot;

        SetHeight(node);
        SetHeight(newRoot);
        return newRoot;
    }

    private TreeNode RightRotation(TreeNode node)
    {
        var newRoot = node.LeftNode;
        var currentRightNodeOnNewRoot = newRoot.RightNode;

        newRoot.RightNode = node;
        node.LeftNode = currentRightNodeOnNewRoot;

        SetHeight(node);
        SetHeight(newRoot);
        return newRoot;
    }

    private void SetHeight(TreeNode node)
    {
        node.Height = Math.Max(node.LeftNode.Height, node.RightNode.Height) + 1;
    }
}
