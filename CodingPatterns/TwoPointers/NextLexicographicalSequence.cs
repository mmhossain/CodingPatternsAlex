namespace CodingPatterns.TwoPointers;

public class NextLexicographicalSequence
{
    /*
        Time: O(n)
        Space: O(n)
            n = number of characters in str
    */
    public string NextLexicographicalSequence_Optimized(string str)
    {
        char[] letters = str.ToCharArray(); // O(n) space

        int pivot = str.Length - 2;
        while (pivot >= 0 && letters[pivot] >= letters[pivot + 1])  // O(n) time
            pivot--;

        if (pivot == -1)
            return reverse(letters, 0, str.Length - 1); // O(n) time

        int rightmostSuccessor = str.Length - 1;
        while (letters[rightmostSuccessor] <= letters[pivot])   // O(n) time
            rightmostSuccessor--;

        (letters[pivot], letters[rightmostSuccessor]) = (letters[rightmostSuccessor], letters[pivot]);

        return reverse(letters, pivot + 1, str.Length - 1); // O(n) time
    }

    public string reverse(char[] chars, int start, int end)
    {
        while (start < end)
        {
            (chars[start], chars[end]) = (chars[end], chars[start]);
            start++;
            end--;
        }

        return new string(chars);
    }
}
