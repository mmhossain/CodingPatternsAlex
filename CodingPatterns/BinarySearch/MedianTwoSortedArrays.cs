namespace CodingPatterns.BinarySearch;

public class MedianTwoSortedArrays
{
    /*
        Time: O(log min(m, n))
        Space: O(1)
            m = nums1.Count
            n = nums2.Count
    */
    public double FindMedianFromTwoSortedArrays(List<int> nums1, List<int> nums2)
    {
        if (nums1.Count > nums2.Count)
            (nums1, nums2) = (nums2, nums1);

        int m = nums1.Count;
        int n = nums2.Count;

        int halfTotalLength = (m + n) / 2;
        int left = 0, right = m - 1;

        while (true)
        {
            int l1Index = left + (right - left) / 2;
            int l2Index = halfTotalLength - (l1Index + 1) - 1;

            int l1 = l1Index < 0 ? int.MinValue : nums1[l1Index];
            int r1 = (l1Index + 1) >= m ? int.MaxValue : nums1[l1Index + 1];

            int l2 = l2Index < 0 ? int.MinValue : nums2[l2Index];
            int r2 = (l2Index + 1) >= n ? int.MaxValue : nums2[l2Index + 1];

            if (l1 > r2)
                right = l1Index - 1;
            else if (l2 > r1)
                left = l1Index + 1;
            else
            {
                if ((m + n) % 2 == 0)
                    return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0;
                else
                    return Math.Min(r1, r2);
            }
        }
    }
}
