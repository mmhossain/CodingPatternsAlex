using Domain;

namespace CodingPatterns.Trees;

public class KthSmallestInBinaryTree
{
    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) since the call stack can have n nodes
            n = number of nodes in the tree
    */
    public int FindKthSmallestInBT_Recursive(BTTreeNode root, int k)
    {
        List<int> sortedNums = [];
        inorder(root, sortedNums);

        return sortedNums[k - 1];
    }

    private void inorder(BTTreeNode node, List<int> sortedNums)
    {
        if (node == null) 
            return;

        inorder(node.Left, sortedNums);
        sortedNums.Add(node.Value);
        inorder(node.Right, sortedNums);
    }

    /*
        Time: O(n)  since we need to visit all nodes
        Space: O(n) stack can have at most n nodes for skew tree
            n = number of nodes in the tree
    */
    public int FindKthSmallestInBT_Iterative(BTTreeNode root, int k)
    {
        Stack<BTTreeNode> stack = [];
        BTTreeNode current = root;

        while (true)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }

            current = stack.Pop();

            if (--k == 0)
                return current.Value;

            current = current.Right;
        }
    }
}
