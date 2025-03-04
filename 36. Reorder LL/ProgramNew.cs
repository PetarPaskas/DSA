using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36._Reorder_LL;

public class Solution
{

    public static void ShowItems(ListNode LL)
    {
        while(LL != null)
        {
            Console.WriteLine(LL.val);
            LL = LL.next;
        }
    }

    public static void DoIt(ListNode head)
    {
        new Solution().ReorderList(head);
    }
    public void ReorderList(ListNode LL)
    {
        var items = GetList(LL);

        var result = items[0];
        var currentHead = result;


        int i = 1;
        int iterator = 1;

        while (i < items.Count)
        {

            if (i % 2 == 0)
            {
                currentHead.next = items[iterator];
                iterator++;
            }
            else
                currentHead.next = items[items.Count - iterator];

            currentHead = currentHead.next;
            i++;
        }
        currentHead.next = null;
        LL = result;
    }

    private List<ListNode> GetList(ListNode LL)
    {
        List<ListNode> items = new List<ListNode>();

        var head = LL;
        while (head != null)
        {
            items.Add(head);
            head = head.next;
        }

        return items;
    }

}
