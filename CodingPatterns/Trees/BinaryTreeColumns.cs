using Domain;

namespace CodingPatterns.Trees;

public class BinaryTreeColumns
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the map can contain n nodes, and the queue can have at most n/2 items
            n = number of nodes in the tree
    */
    public List<List<int>> TraverseBTColumnwise(BTTreeNode root)
    {
        if (root == null) return [];

        int leftmostIndex = 0, rightmostIndex = 0;
        Dictionary<int, List<int>> columnMap = [];

        Queue<(BTTreeNode node, int colIndex)> queue = [];
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            (BTTreeNode node, int colIndex) = queue.Dequeue();
            if (node == null) continue;

            if (!columnMap.ContainsKey(colIndex))
                columnMap[colIndex] = [];
            columnMap[colIndex].Add(node.Value);

            leftmostIndex = Math.Min(leftmostIndex, colIndex);
            rightmostIndex = Math.Max(rightmostIndex, colIndex);

            queue.Enqueue((node.Left, colIndex - 1));
            queue.Enqueue((node.Right, colIndex + 1));
        }

        List<List<int>> result = [];
        for (int i = leftmostIndex; i <= rightmostIndex; i++)
            result.Add(columnMap[i]);

        return result;
    }
}
