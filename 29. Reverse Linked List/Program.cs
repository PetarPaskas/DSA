 



public class ListNode {
     public int val;
     public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
         this.val = val;
        this.next = next;
    }
  }

public class Solution
{
    private Stack<int> _stack = new Stack<int>(); //Jako lose resenje, bukvalno sam zaboravio kako se radi sve

    public ListNode ReverseList(ListNode head)
    {

        PopulateStack(head);

        if (_stack.Count == 0)
            return null;

        ListNode resultNode = new ListNode(_stack.Pop());
        var first = resultNode;

        while (_stack.Count > 0)
        {
            var next = new ListNode(_stack.Pop());
            resultNode.next = next;
            resultNode = next;
        }

        return first;
    }

    private void PopulateStack(ListNode head)
    {
        if (head == null)
            return;

        _stack.Push(head.val);

        PopulateStack(head.next);
    }
}