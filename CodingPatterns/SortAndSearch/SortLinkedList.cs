using Domain;

namespace CodingPatterns.SortAndSearch;

public class SortLinkedList
{
    /*
        Time: O(n log n)
            - we can partition in half at most O(log n) times, and merge takes O(n) times
        Space: O(log n)
            - the recursion stack can take up to O(log n)

            n = number of nodes in the LinkedList
    */
    public ListNode SortLinkedList_MergeSort(ListNode head)
    {
        if (head == null || head.Next == null)
            return head;

        ListNode secondHead = splitList(head);
        ListNode firstHalfSorted = SortLinkedList_MergeSort(head);
        ListNode secondHalfSorted = SortLinkedList_MergeSort(secondHead);

        return merge(firstHalfSorted, secondHalfSorted);
    }

    private ListNode splitList(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        ListNode secondHead = slow.Next;
        slow.Next = null;

        return secondHead;
    }

    private ListNode merge(ListNode list1, ListNode list2)
    {
        ListNode dummyHead = new ListNode(-1);
        ListNode tail = dummyHead;

        while (list1 != null && list2 != null)
        {
            if (list1.Val < list2.Val)
            {
                tail.Next = list1;
                list1 = list1.Next;
            }
            else
            {
                tail.Next = list2;
                list2 = list2.Next;
            }

            tail = tail.Next;
        }

        tail.Next = list1 ?? list2;

        return dummyHead.Next;
    }
}
