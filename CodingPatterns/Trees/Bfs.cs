using Domain;

namespace CodingPatterns.Trees;

public class Bfs
{
    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) since each level can have at most n/2 nodes
            n = number of nodes in the tree
    */
    public List<int> Bfs_Template(BTTreeNode root)
    {
        if (root == null)
            return [];

        List<int> result = [];

        Queue<BTTreeNode> queue = new Queue<BTTreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                BTTreeNode node = queue.Dequeue();
                result.Add(node.Value);

                if (node.Left != null)
                    queue.Enqueue(node.Left);

                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }

        return result;
    }
}
