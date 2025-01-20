using Domain;

namespace CodingPatterns.Trees;

public class GraphDeepCopy
{
    /*
        Time: O(v + e)  since we need to visit all vertices and edges
        Space: O(v) since the recursion stack can have up to v vertives
            v = number of vertices in the graph
            e = number of edges in the graph
    */
    public GraphNode DeepCopyOfAGraph(GraphNode node)
    {
        if (node == null)
            return null;

        Dictionary<GraphNode, GraphNode> cloneMap = [];

        return dfs(node, cloneMap);
    }

    private GraphNode dfs(GraphNode node, Dictionary<GraphNode, GraphNode> cloneMap)
    {
        if (cloneMap.ContainsKey(node))
            return cloneMap[node];

        GraphNode clonedNode = new GraphNode(node.Value);
        cloneMap[node] = clonedNode;

        foreach (GraphNode neighbor in node.Neighbors)
        {
            GraphNode clonedNeighbor = dfs(neighbor, cloneMap);
            clonedNode.Neighbors.Add(clonedNeighbor);
        }

        return clonedNode;
    }
}
