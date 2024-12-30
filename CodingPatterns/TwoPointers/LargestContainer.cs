namespace CodingPatterns.TwoPointers;

public class LargestContainer
{
    /*
        Time: O(n^2)
        Space: O(1)
            n = number of elements in heights
    */
    public int LargestContainer_Brute_Force(List<int> heights)
    {
        int n = heights.Count;
        int maxWater = 0;

        for (int i = 0; i < n; i++) // O(n) time
        {
            for (int j = i + 1; j < n; j++) // O(n) time
            {
                int water = Math.Min(heights[i], heights[j]) * (j - i);
                maxWater = Math.Max(maxWater, water);
            }
        }

        return maxWater;
    }

    /*
        Time: O(n)
        Space: O(1)
            n = number of elements in heights
    */
    public int LargestContainer_Optimized(List<int> heights)
    {
        int left = 0, right = heights.Count - 1;
        int maxWater = 0;

        while (left < right)
        {
            int water = Math.Min(heights[left], heights[right]) * (right - left);
            maxWater = Math.Max(maxWater, water);

            if (heights[left] < heights[right])
                left++;
            else if (heights[left] > heights[right])
                right--;
            else
            {
                left++;
                right--;
            }
        }

        return maxWater;
    }
}
