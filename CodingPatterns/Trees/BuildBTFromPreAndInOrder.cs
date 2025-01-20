using Domain;

namespace CodingPatterns.Trees;

public class BuildBTFromPreAndInOrder
{
    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) since the recursion stack can have up to n nodes
            n = number of nodes in the tree
    */
    public BTTreeNode BinaryTreeFromPreOrderAndInOrderTraversal(List<int> preorder, List<int> inorder)
    {
        Dictionary<int, int> inorderMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Count; i++)
            inorderMap[inorder[i]] = i;
        
        return buildTree(0, preorder.Count - 1, [0], preorder, inorderMap);
    }

    private BTTreeNode buildTree(
        int left, int right, int[] preorderIndex, List<int> preorder, Dictionary<int, int> inorderMap)
    {
        if (left > right)
            return null;

        int value = preorder[preorderIndex[0]++];
        BTTreeNode root = new BTTreeNode(value);
        root.Left = buildTree(left, inorderMap[value] - 1, preorderIndex, preorder, inorderMap);
        root.Right = buildTree(inorderMap[value] + 1, right, preorderIndex, preorder, inorderMap);

        return root;
    }
}
