using Domain;

namespace CodingPatterns.Trees;

public class MaximumPathSumOfBT
{
    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) since the recursion stack can have up to n nodes
            n = number of nodes in the tree
    */
    public int MaxPathSum(BTTreeNode root)
    {
        int[] result = new int[1];

        dfs(root, result);

        return result[0];
    }

    private int dfs(BTTreeNode node, int[] result)
    {
        if (node == null)
            return 0;

        int leftSum = Math.Max(dfs(node.Left, result), 0);
        int rightSum = Math.Max(dfs(node.Right, result), 0);

        result[0] = Math.Max(result[0], node.Value + leftSum + rightSum);

        return node.Value + Math.Max(leftSum, rightSum);
    }
}
