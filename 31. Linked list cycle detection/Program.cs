// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var node1 = new ListNode(1);
var node2 = new ListNode(2);
var node3 = new ListNode(3);

node1.next = node2;
node2.next = node3;
node3.next = node1;

Console.WriteLine(HasCycle(node1));

bool HasCycle(ListNode head)
{
    HashSet<int> hash = new HashSet<int>();
    var current = head;
    while (current != null)
    {
        if (!hash.Contains(current.GetHashCode()))
            hash.Add(current.GetHashCode());
        else return true;

        current = current.next;
    }
    return false;
}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
