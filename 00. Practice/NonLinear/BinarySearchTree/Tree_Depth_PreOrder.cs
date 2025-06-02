using System;

public static class Tree_Depth_PreOrder
{
    public static void Test()
    {
        var tree = new Tree();
        int[] items = [20,10,30,14,6,8,3,24,26];
        foreach(var item in items)
            tree.Insert(item);

        tree.PreOrderTraversal();
    }
}