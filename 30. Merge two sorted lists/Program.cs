


MergeTwoLists(null, null);


ListNode MergeTwoLists(ListNode list1, ListNode list2)
{
    if (list1 == null) return list2;
    if (list2 == null) return list1;

    

    if(list1.val < list2.val)
    {
        list1.next = MergeTwoLists(list1.next, list2);
        return list1;
    }
    else
    {
       list2.next = MergeTwoLists(list1, list2.next);
        return list2;
    }
}

ListNode MergeTwoListsIteration(ListNode list1, ListNode list2)
{
    var dummy = new ListNode();
    var tail = dummy;

    while (list1 != null && list2 != null)
    {
        if (list1.val < list2.val)
        {
            tail.next = list1;
            list1 = list1.next;
        }
        else
        {
            tail.next = list2;
            list2 = list2.next;
        }
        tail = tail.next;
    }

    if (list1 == null)
        tail.next = list2;
    else
        tail.next = list1;

    return dummy.next;
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


