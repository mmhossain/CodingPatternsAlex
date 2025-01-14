using Domain;

namespace CodingPatterns.Trees;

public class BalancedBinaryTreeValidation
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion can go up to n
            n = number of nodes in the tree
    */
    public bool ValidateBalancedBinaryTree(BTTreeNode root)
    {
        return helper(root) != -1;
    }

    private int helper(BTTreeNode root)
    {
        if (root == null)
            return 0;

        int leftHeight = helper(root.Left);
        int rightHeight = helper(root.Right);

        if (leftHeight == -1 || rightHeight == -1)
            return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
