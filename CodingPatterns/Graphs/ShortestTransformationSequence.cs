namespace CodingPatterns.Trees;

public class ShortestTransformationSequence
{
    /*
        Time: O(n x L^2) since we process n words and each word has length L characters to replace
        Space: O(n x L) for the dictionarySet
            n = number of words in the dictionary
            L = average length of each word
    */
    public int ShortestTransformationSequenceLength(string start, string end, List<string> dictionary)
    {
        ISet<string> dictionarySet = new HashSet<string>(dictionary);

        if (!dictionarySet.Contains(start) || !dictionarySet.Contains(end))
            return 0;

        if (start == end)
            return 1;

        string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";

        Queue<string> queue = new Queue<string>();
        queue.Enqueue(start);

        HashSet<string> visited = new HashSet<string> { start };

        int dist = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                string currWord = queue.Dequeue();

                if (currWord == end)
                    return dist + 1;

                for (int j = 0; j < currWord.Length; j++)
                {
                    foreach (char c in lowercaseLetters)
                    {
                        string nextWord = currWord.Substring(0, j) + c + currWord.Substring(j + 1);

                        if (dictionarySet.Contains(nextWord) && !visited.Contains(nextWord))
                        {
                            visited.Add(nextWord);
                            queue.Enqueue(nextWord);
                        }
                    }
                }
            }

            dist++;
        }

        return 0;
    }

    /*
        Time: O(n x L^2) since we process n words and each word has length L characters to replace
        Space: O(n x L) for the dictionarySet
            n = number of words in the dictionary
            L = average length of each word
    */
    public int ShortestTransformationSequenceLength_Optimized(
        string start, string end, List<string> dictionary)
    {
        ISet<string> dictionarySet = new HashSet<string>(dictionary);   // O(n.L)

        if (!dictionarySet.Contains(start) || !dictionary.Contains(end))
            return 0;

        if (start == end)
            return 1;

        Queue<string> startQ = [];
        startQ.Enqueue(start);

        ISet<string> startVisited = new HashSet<string>();
        startVisited.Add(start);

        Queue<string> endQ = [];
        endQ.Enqueue(end);

        ISet<string> endVisited = new HashSet<string>();
        endVisited.Add(end);

        int startLevel = 0, endLevel = 0;

        while (startQ.Count > 0 && endQ.Count > 0)
        {
            startLevel++;
            if (exploreLevel(startQ, startVisited, endVisited, dictionarySet))
                return startLevel + endLevel + 1;

            endLevel++;
            if (exploreLevel(endQ, endVisited, startVisited, dictionarySet))
                return startLevel + endLevel + 1;
        }

        return 0;
    }

    private bool exploreLevel(
        Queue<string> queue, ISet<string> visited, ISet<string> otherVisited, ISet<string> dictionary)
    {
        string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        int levelSize = queue.Count;

        for (int i = 0; i < levelSize; i++) // O(n)
        {
            string currentWord = queue.Dequeue();

            for (int j = 0; j < currentWord.Length; j++)    // O(L)
            {
                foreach (char ch in lowercaseLetters)
                {
                    string nextWord = currentWord[..j] + ch + currentWord[(j + 1)..];
                    if (otherVisited.Contains(nextWord))
                        return true;

                    if (dictionary.Contains(nextWord) && !visited.Contains(nextWord))   // O(L)
                    {
                        visited.Add(nextWord);
                        queue.Enqueue(nextWord);
                    }
                }
            }
        }

        return false;
    }
}
