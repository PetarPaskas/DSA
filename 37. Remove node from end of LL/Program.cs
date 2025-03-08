




int[] items = [1,2];
int n = 2;

var head = new ListNode();

var initHead = head;

foreach (var item in items)
{
    head.next = new ListNode(item);
    head = head.next;
}

RemoveNthFromEnd(initHead.next, n);



ListNode RemoveNthFromEnd(ListNode head, int n)
{
    var dummyLeft = new ListNode(0, head);

    var left = dummyLeft;
    var right = GetNthFromTheFront(head, n);


    while (right != null)
    {
        right = right.next;
        left = left.next;
    }

    left.next = left.next.next;

    return dummyLeft.next;
}

ListNode GetNthFromTheFront(ListNode head, int n)
{
    int i = 0;
    ListNode result = head;
    while(i < n)
    {
        result = result?.next;
        i++;
    }

    return result;
}






class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

