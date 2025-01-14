using Domain;

namespace CodingPatterns.Trees;

public class BinarySearchTreeValidation
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion stack can have up to n nodes
            n = number of nodes in the tree
    */
    public bool ValidateBinarySearchTree(BTTreeNode root)
    {
        return isWithinBound(root, int.MinValue, int.MaxValue);
    }

    private bool isWithinBound(BTTreeNode root, int lowerBound, int upperBound)
    {
        if (root == null)
            return true;

        if (root.Value <= lowerBound || root.Value >= upperBound)
            return false;

        if (!isWithinBound(root.Left, lowerBound, root.Value))
            return false;

        return isWithinBound(root.Right, root.Value, upperBound);
    }
}
