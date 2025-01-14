using Domain;

namespace CodingPatterns.Trees;

public class WidestBinaryTreeLevel
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the queue can have at most n/2 nodes
            n = number of nodes in the tree
    */
    public int WidestLevelOfABinaryTree(BTTreeNode root)
    {
        if (root == null)
            return 0;

        int maxWidth = 0;
        Queue<(BTTreeNode node, int index)> queue = new Queue<(BTTreeNode node, int index)>();
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            int leftIndex = queue.Peek().index;
            int rightIndex = queue.Peek().index;

            for (int i = 0; i < levelSize; i++)
            {
                (BTTreeNode node, int index) = queue.Dequeue();
                rightIndex = index;

                if (node.Left != null)
                    queue.Enqueue((node.Left, 2 * index + 1));

                if (node.Right != null)
                    queue.Enqueue((node.Right, 2 * index + 2));
            }

            maxWidth = Math.Max(maxWidth, rightIndex - leftIndex + 1);
        }

        return maxWidth;
    }
}
