

int[] items = [1, 2, 3, 4];
ListNode initHead = new ListNode();
ListNode head = initHead;
foreach(var item in items)
{
    initHead.next = new ListNode(item);
    initHead = initHead.next;
}

var res = new BetterSolution().ReverseList(head);



    
    public class ListNode {
     public int val;
     public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
         this.val = val;
        this.next = next;
    }
  }


public class BetterSolution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previous = null;
        var current = head;

        while (current != null)
        {
            var next = current.next;

            current.next = previous;
            previous = current;
            current = next;
        }

        return previous;
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



