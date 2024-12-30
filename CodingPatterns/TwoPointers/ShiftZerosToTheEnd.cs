namespace CodingPatterns.TwoPointers;

public class ShiftZerosToTheEnd
{
    /*
        Time: O(n)
        Space: O(n)
            n = number of elements in nums
    */
    public void ShiftZerosToTheEnd_Naive(List<int> nums)
    {
        int n = nums.Count;
        int[] temp = new int[n];    // O(n) space
        int i = 0;

        foreach (int num in nums)   // O(n) time
        {
            if (num != 0)
                temp[i++] = num;
        }

        for (int j = 0; j < n; j++) // O(n) time
            nums[j] = temp[j];
    }

    /*
        Time: O(n)
        Space: O(1)
            n = number of elements in nums
    */
    public void ShiftZerosToTheEnd_Optimized(List<int> nums)
    {
        int left = 0;

        for (int right = 0; right < nums.Count; right++) // O(n) time
        {
            if (nums[right] != 0)
            {
                (nums[left], nums[right]) = (nums[right], nums[left]);
                left++;
            }
        }
    }
}
