using Domain;

namespace CodingPatterns;

public class SortAndSearch
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

        while (fast.Next != null && fast.Next.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        ListNode secondHead = slow.Next;
        slow.Next = null;

        return secondHead;
    }

    private ListNode merge(ListNode first, ListNode second)
    {
        ListNode dummyHead = new ListNode(-1);
        ListNode tail = dummyHead;

        while (first != null && second != null)
        {
            if (first.Val < second.Val)
            {
                tail.Next = first;
                first = first.Next;
            }
            else
            {
                tail.Next = second;
                second = second.Next;
            }

            tail = tail.Next;
        }

        tail.Next = first ?? second;

        return dummyHead.Next;
    }

    /*
        Time: 
            Average case O(n log n), we can partition in half at most O(log n) times, 
                and each partition takes O(n) times for pivot index
            Worst case O(n^2), if the pivot selection always partitions the array to put most of the 
                items in one part
        Space: 
            Averate case O(log n), the recursion stack can take up to O(log n)
            Worst case O(n), the recursion stack can take up to O(n)

            n = number of items in the List
    */
    public List<int> SortArray_QuickSort(List<int> nums)
    {
        if (nums == null || nums.Count == 0)
            return nums;

        quickSort(nums, 0, nums.Count - 1);

        return nums;
    }

    private void quickSort(List<int> nums, int left, int right)
    {
        if (left >= right)
            return;

        int pivotIndex = partition(nums, left, right);
        quickSort(nums, left, pivotIndex - 1);
        quickSort(nums, pivotIndex + 1, right);
    }

    private int partition(List<int> nums, int left, int right)
    {
        int low = left;
        int pivot = nums[right];

        for (int i = left; i < right; i++)
        {
            if (nums[i] < pivot)
            {
                (nums[low], nums[i]) = (nums[i], nums[low]);
                low++;
            }
        }

        (nums[low], nums[right]) = (nums[right], nums[low]);

        return low;
    }

    /*
        Time: O(n log n), we can partition in half at most O(log n) times, 
            and each partition takes O(n) times for the pivot index
            - this solution reduces the chances of O(n^2) time complexity by using random pivot selection
        Space: 
            Averate case O(log n), the recursion stack can take up to O(log n)
            Worst case O(n), the recursion stack can take up to O(n)

            n = number of items in the List
    */
    public List<int> SortArray_QuickSort_Optimized(List<int> nums)
    {
        if (nums == null || nums.Count == 0)
            return nums;

        quickSort_Optimized(nums, 0, nums.Count - 1);

        return nums;
    }

    private void quickSort_Optimized(List<int> nums, int left, int right)
    {
        if (left >= right)
            return;

        int randomIndex = new Random().Next(left, right);
        (nums[randomIndex], nums[right]) = (nums[right], nums[randomIndex]);

        int pivotIndex = partition(nums, left, right);
        quickSort(nums, left, pivotIndex - 1);
        quickSort(nums, pivotIndex + 1, right);
    }

    /*
        Time: O(n + k), counting each number occurence takes O(n) and building the result takes O(k)
        Space: O(k), this holds the counts array
            
            n = number of items in the List
            k = max value in the list
    */
    public List<int> SortArray_CountingSort(List<int> nums)
    {
        if (nums == null || nums.Count == 0)
            return nums;

        int[] counts = new int[nums.Max() + 1];

        foreach (int num in nums)
            counts[num]++;

        int[] result = new int[nums.Count];
        int k = 0;
        
        for (int i = 0; i < counts.Length; i++)
        {
            for (int j = 0; j < counts[i]; j++)
                result[k++] = i;
        }

        return [.. result];
    }

    /*
        Time: O(n log k), we put each number in the minheap, and the heap can have at most k items
        Space: O(k)
            
            n = number of items in the List
    */
    public int KthLargestNumber_MinHeap(List<int> nums, int k)
    {
        PriorityQueue<int, int> minHeap = new(Comparer<int>.Create((x, y) => x.CompareTo(y)));

        foreach (int num in nums)
        {
            if (minHeap.Count < k)
                minHeap.Enqueue(num, num);
            else if (num > minHeap.Peek())
            {
                minHeap.Dequeue();
                minHeap.Enqueue(num, num);
            }
        }

        return minHeap.Peek();
    }

    /*
        Time: average case O(n), since each partition removes half of the items
        Space: average case O(log n), worst case O(n)
            n = number of items in the List
    */
    public int KthLargestNumber_QuickSelect(List<int> nums, int k)
    {
        return quickSelect(nums, 0, nums.Count - 1, k);
    }

    private int quickSelect(List<int> nums, int left, int right, int k)
    {
        if (left >= right)
            return nums[left];

        int randomIndex = new Random().Next(left, right);
        (nums[randomIndex], nums[right]) = (nums[right], nums[randomIndex]);

        int n = nums.Count;
        int pivot_index = partition(nums, left, right);

        if (pivot_index < n - k)
            return quickSelect(nums, pivot_index + 1, right, k);
        else if (pivot_index > n - k)
            return quickSelect(nums, left, pivot_index - 1, k);
        else
            return nums[pivot_index];
    }

    /*
        Time: O(n)
        Space: O(1)
            n = number of items in the List
    */
    public void DutchNationalFlag(List<int> nums)
    {
        int i = 0, left = 0, right = nums.Count - 1;

        while (i <= right)
        {
            if (nums[i] == 0)
            {
                (nums[left], nums[i]) = (nums[i], nums[left]);
                i++;
                left++;
            }
            else if (nums[i] == 2)
            {
                (nums[i], nums[right]) = (nums[right], nums[i]);
                right--;
            }
            else
            {
                i++;
            }
        }
    }
}
