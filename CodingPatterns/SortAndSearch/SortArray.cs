namespace CodingPatterns.SortAndSearch;

public class SortArray
{
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
}
