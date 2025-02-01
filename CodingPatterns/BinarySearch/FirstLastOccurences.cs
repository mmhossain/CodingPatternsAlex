namespace CodingPatterns.BinarySearch;

public class FirstLastOccurences
{
    /*
        Time: O(log n)
        Space: O(1)
            n = nums.Count
    */
    public int[] FindFirstLastOccurencesOfANumber(List<int> nums, int target)
    {
        int firstIndex = findLowerBound(nums, target);
        int lastIndex = findUpperBound(nums, target);

        return [firstIndex, lastIndex];
    }

    private int findLowerBound(List<int> nums, int target)
    {
        int left = 0, right = nums.Count - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] > target)
                right = mid - 1;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        return nums[left] == target ? left : -1;
    }

    private int findUpperBound(List<int> nums, int target)
    {
        int left = 0, right = nums.Count - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2 + 1;

            if (nums[mid] > target)
                right = mid - 1;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                left = mid;
        }

        return nums[right] == target ? right : -1;
    }
}
