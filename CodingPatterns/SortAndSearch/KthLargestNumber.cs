namespace CodingPatterns.SortAndSearch;

public class KthLargestNumber
{
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
}
