namespace CodingPatterns.SortAndSearch;

public class DutchNationalFlag
{
    /*
        Time: O(n)
        Space: O(1)
            n = number of items in the List
    */
    public void DutchNationalFlag_Optimized(List<int> nums)
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
