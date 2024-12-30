namespace CodingPatterns.TwoPointers;

public class PalindromeValid
{
    /*
        Time: O(n)
        Space: O(1)
            n = number of characters in s
    */
    public bool IsPalindomeValid(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)    // O(n) time
        {
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;

            while (right > left && !char.IsLetterOrDigit(s[right]))
                right--;

            if (s[left] != s[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
