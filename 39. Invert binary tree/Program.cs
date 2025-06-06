namespace InvertBinaryTree;

 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
      }
  }


public class Program {

    public static void main(String[] args)
    {
        Console.WriteLine("Do your inversion here:");
    }
    public TreeNode InvertTree(TreeNode root)
    {
        PreOrderTraversal(root);
        return root;
    }

    private void PreOrderTraversal(TreeNode node){
        if(node == null) return;
        Invert(node);
        PreOrderTraversal(node.left);
        PreOrderTraversal(node.right);
    }

    private void Invert(TreeNode node){
        var lNodeOld = node.left;
        node.left = node.right;
        node.right = lNodeOld;
    }
}
