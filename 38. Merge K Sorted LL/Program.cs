
int[] first = [1,1];
int[] second = [1];
int[] third = [4,5];


ListNode[] lists = [
    GetHeadFromList(first),
    GetHeadFromList(second),
    GetHeadFromList(third),
];

var result = MergeKLists(lists);

while(result != null)
{
    Console.WriteLine(result.val);
    result = result.next;
}

ListNode MergeKLists(ListNode[] lists)
{
    if (lists.Length == 0)
        return null;

    var dummy = new ListNode();
    var result = dummy;
    var smallestItem = lists[0];
    int selectedList = 0;

    while (true)
    {
        var countedLists = 0;

        for (int i = 0; i < lists.Length; i++)
        {
            var current = lists[i];

            if (current == null)
            {
                countedLists++;
                continue;
            }

            if (smallestItem == null || current.val < smallestItem.val)
            {
                smallestItem = current;
                selectedList = i;
            }
        }

        if (countedLists == lists.Length)
            break;

        dummy.next = smallestItem;
        dummy = dummy.next;

        smallestItem = smallestItem.next;
        lists[selectedList] = smallestItem;

        dummy.next = null;
    }

    return result.next;
}



ListNode GetHeadFromList(int[] items)
{
    var dummy = new ListNode();

    var initHead = dummy;

    foreach (var item in items)
    {
        dummy.next = new ListNode(item);
        dummy = dummy.next;
    }

    return initHead.next;
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
