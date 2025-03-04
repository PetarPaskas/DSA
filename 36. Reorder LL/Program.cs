
using _36._Reorder_LL;

int[] items = [2, 4, 6, 8];

var head = new ListNode();

var initHead = head;

foreach (var item in items)
{
    head.next = new ListNode(item);
    head = head.next;
}

;

//You may not modify the values in the list's nodes, but instead you must reorder the nodes themselves.
//MISSED THIS, ANOTHER TIME I GUESS
Solution.DoIt(initHead.next);
Solution.ShowItems(initHead.next);

ListNode ReorderList(ListNode LL)
{
    var items = GetList(LL);

    var result = new ListNode(items[0]);

    var iterator = result;

   
    int i = 1;
    int skipper = 1;

    while (i < items.Count) {
        ListNode node = new ListNode();

        if (i % 2 == 0)
        {
            node.val = items[skipper];
            skipper++;
        }
        else
            node.val = items[items.Count- skipper];

        iterator.next = node;
        iterator = node;
        i++;
    }

    return result;
}

List<int> GetList(ListNode LL)
{
    List<int> items = new List<int>();

    var head = LL;
    while (head != null)
    {
        items.Add(head.val);
        head = head.next;
    }

    return items;
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
