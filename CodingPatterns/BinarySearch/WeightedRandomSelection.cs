namespace CodingPatterns.BinarySearch;

public class WeightedRandomSelection
{
    List<int> prefixSums = [];

    public WeightedRandomSelection(List<int> weights)
    {
        prefixSums.Add(weights[0]);

        for (int i = 1; i < weights.Count; i++)
            prefixSums.Add(prefixSums[i - 1] + weights[i]);
    }

    /*
        Time: O(log n)
        Space: O(1)
            n = nums.Count
    */
    public int Select()
    {
        int target = new Random().Next(1, prefixSums[^1]);

        int left = 0, right = prefixSums.Count - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (prefixSums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}
