using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37._Remove_node_from_end_of_LL
{
    internal class DoublyLL
    {
        public void Execute()
        {

            int[] items = [1, 2, 3, 4];
            int n = 4;

            var head = new ListNode();

            var initHead = head;

            foreach (var item in items)
            {
                head.next = new ListNode(item);
                head = head.next;
            }


            var result = RemoveNthFromEnd(initHead.next, n);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

            ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                DoublyLinkedList initHead = new DoublyLinkedList(null);
                DoublyLinkedList start = initHead;
                DoublyLinkedList prev = null;
                while (head != null)
                {
                    initHead.next = new DoublyLinkedList(head);
                    initHead.previous = prev;
                    prev = initHead;
                    initHead = initHead.next;
                    head = head.next;
                }
                initHead.previous = prev;

                start.next.previous = null;

                int i = 0;
                DoublyLinkedList search = initHead;

                while (i < n)
                {
                    if (i == (n - 1))
                    {
                        bool hasNoPrev = search.previous == null;
                        bool hasNoNext = search.next == null;

                        if (hasNoPrev && hasNoNext)
                            return null;

                        if (hasNoNext)
                        {
                            search.previous.value.next = null;
                            break;
                        }

                        if (hasNoPrev)
                            return search.next.value;

                        search.previous.value.next = search.next.value;
                    }
                    search = search.previous;
                    i++;
                }

                return start.next.value;
            }



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

        public class DoublyLinkedList
        {
            public ListNode value;
            public DoublyLinkedList next;
            public DoublyLinkedList previous;

            public DoublyLinkedList(ListNode item)
            {
                value = item;
            }
        }

    }
}
