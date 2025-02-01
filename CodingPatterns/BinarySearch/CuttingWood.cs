namespace CodingPatterns.BinarySearch;

public class CuttingWood
{
    /*
        Time: O(log n)
        Space: O(1)
            n = maximum heights in heights list
    */
    public int FindMaxHeight(List<int> heights, int k)
    {
        int left = 0, right = heights.Max();

        while (left < right)
        {
            int mid = left + (right - left) / 2 + 1;

            if (canCutToHeight(heights, k, mid))
                left = mid;
            else
                right = mid - 1;
        }

        return right;
    }

    private bool canCutToHeight(List<int> heights, int k, int h)
    {
        int woodsCollected = 0;

        foreach (int height in heights)
        {
            if (height > h)
                woodsCollected += (height - h);
        }

        return woodsCollected >= k;
    }
}
