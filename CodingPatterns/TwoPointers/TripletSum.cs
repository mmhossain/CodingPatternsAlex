namespace CodingPatterns.TwoPointers;

public class TripletSum
{
    /*
        Time: O(n^3)
        Space: O(1), we don't consider output space
            n = number of elements in nums
    */
    public List<List<int>> TripletSum_Brute_Force(List<int> nums)
    {
        int n = nums.Count;
        ISet<List<int>> triplets = new HashSet<List<int>>();

        for (int i = 0; i < n - 2; i++) // O(n) time
        {
            for (int j = i + 1; j < n - 1; j++) // O(n) time
            {
                for (int k = j + 1; k < n; k++) // O(n) time
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        List<int> triplet = [nums[i], nums[j], nums[k]];
                        triplet.Sort();
                        triplets.Add(triplet);
                    }
                }
            }
        }

        return [.. triplets];
    }

    /*
        Time: O(n^2)
        Space: O(1), we don't consider output space, otherwise O(n^2)
            n = number of elements in nums
    */
    public List<List<int>> TripletSum_Optimized(List<int> nums)
    {
        nums.Sort();    // O(n log n) time

        int n = nums.Count;
        List<List<int>> triplets = [];

        for (int i = 0; i < n - 2; i++) // O(n) time
        {
            // triplets consisting of only positive numbers will never sum to 0
            if (nums[i] > 0)
                break;

            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            List<List<int>> pairs = twoSum(nums, i + 1, -nums[i]);    // O(n) time
            
            // O(n^2) space for triplets, since we add approximately n pairs
            // and twoSum method called n times
            foreach (List<int> pair in pairs)   
                triplets.Add([nums[i], ..pair]);
        }

        return triplets;
    }

    private List<List<int>> twoSum(List<int> nums, int start, int target)
    {
        List<List<int>> pairs = [];
        int left = start, right = nums.Count - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];

            if (sum == target)
            {
                pairs.Add([nums[left], nums[right]]);
                left++;

                while (left < right && nums[left] == nums[left - 1])
                    left++;
            }
            else if (sum < target)
                left++;
            else
                right--;
        }

        return pairs;
    }
}
