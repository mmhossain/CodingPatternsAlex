namespace CodingPatterns.Trees;

public class Prerequisites
{
    /*
        Time: O(n x L^2) since we process n words and each word has length L characters to replace
        Space: O(n x L) for the dictionarySet
            n = number of words in the dictionary
            L = average length of each word
    */
    public bool CanEnrollInAllCourses(int n, List<List<int>> prerequisites)
    {
        Dictionary<int, List<int>> graph = [];
        int[] inDegree = new int[n];

        foreach (List<int> prerequisite in prerequisites)
        {
            int pre = prerequisite[0], course = prerequisite[1];
            if (!graph.ContainsKey(pre))
                graph[pre] = [];

            graph[pre].Add(course);
            inDegree[course]++;
        }

        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        int enrolledCourses = 0;

        while (queue.Count > 0)
        {
            int course = queue.Dequeue();
            enrolledCourses++;

            if (graph.ContainsKey(course))
            {
                foreach (int neighbor in graph[course])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
        }

        return enrolledCourses == n;
    }
}
