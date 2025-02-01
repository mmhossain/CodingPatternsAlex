namespace CodingPatterns.BinarySearch;

public class InsertionIndex
{
    /*
        Time: O(log n)
        Space: O(1)
            n = nums.Count
    */
    public int FindTheInsertionIndex(List<int> nums, int target)
    {
        int left = 0, right = nums.Count;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] >= target)
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}
