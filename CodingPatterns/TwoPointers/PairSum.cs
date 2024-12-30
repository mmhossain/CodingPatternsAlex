namespace CodingPatterns.TwoPointers;

public class PairSum
{
    /*
        Time: O(n^2)
        Space: O(1)
            n = number of elements in nums
    */
    public List<int> PairSum_Sorted_Brute_Force(List<int> nums, int target)
    {
        int n = nums.Count;

        for (int i = 0; i < n - 1; i++) // O(n) time
        {
            for (int j = i + 1; j < n; j++) // O(n) time
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        return [];
    }

    /*
        Time: O(n)
        Space: O(1)
            n = number of elements in nums
    */
    public List<int> PairSum_Sorted(List<int> nums, int target)
    {
        int left = 0, right = nums.Count - 1;

        while (left < right)    // O(n) time
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
                return [left, right];

            if (sum < target)
                left++;
            else
                right--;
        }

        return [];
    }
}
