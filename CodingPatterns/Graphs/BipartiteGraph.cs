namespace CodingPatterns.Trees;

public class BipartiteGraph
{
    /*
        Time: O(v + e) since we need to visit all vertices and edges
        Space: O(v) the recursion stack can go upto v
            v = total number of vertices in the graph
            e = total number of edges in the graph
    */
    public bool IsBipartiteGraph(List<List<int>> graph)
    {
        int[] colors = new int[graph.Count];

        for (int i = 0; i < graph.Count; i++)
        {
            if (colors[i] == 0 && !dfs(i, 1, graph, colors))
                return false;
        }

        return true;
    }

    private bool dfs(int node, int color, List<List<int>> graph, int[] colors)
    {
        colors[node] = color;

        foreach (int neighbor in graph[node])
        {
            if (colors[neighbor] == color)
                return false;

            if (colors[neighbor] == 0 && !dfs(neighbor, -color, graph, colors))
                return false;
        }

        return true;
    }
}
