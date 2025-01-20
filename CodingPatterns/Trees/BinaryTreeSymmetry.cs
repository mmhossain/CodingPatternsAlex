using Domain;

namespace CodingPatterns.Trees;

public class BinaryTreeSymmetry
{
    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) since the recursion stack can have up to n nodes
            n = number of nodes in the tree
    */
    public bool IsBinaryTreeSymmetryic(BTTreeNode root)
    {
        if (root == null) return true;

        return isSymmetric(root.Left, root.Right);
    }

    private bool isSymmetric(BTTreeNode root1, BTTreeNode root2)
    {
        if (root1 == null && root2 == null)
            return true;

        if (root1 == null || root2 == null)
            return false;

        return root1.Value == root2.Value &&
            isSymmetric(root1.Left, root2.Right) &&
            isSymmetric(root1.Right, root2.Left);
    }
}
