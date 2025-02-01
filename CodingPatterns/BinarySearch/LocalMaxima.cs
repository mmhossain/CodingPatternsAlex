namespace CodingPatterns.BinarySearch;

public class LocalMaxima
{
    /*
        Time: O(log n)
        Space: O(1)
            n = nums.Count
    */
    public int FindLocalMaxima(List<int> nums)
    {
        int left = 0, right = nums.Count - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] < nums[mid + 1])
                left = mid + 1;
            else if (nums[mid] > nums[mid + 1])
                right = mid;
        }

        return left;
    }
}
