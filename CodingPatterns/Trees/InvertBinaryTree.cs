using Domain;

namespace CodingPatterns.Trees;

public class InvertBinaryTree
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion can go up to n
            n = number of nodes in the tree
    */
    public BTTreeNode InvertBinaryTree_Recustive_dfs(BTTreeNode root)
    {
        if (root == null)
            return null;

        // swap left and right
        (root.Left, root.Right) = (root.Right, root.Left);

        InvertBinaryTree_Recustive_dfs(root.Left);
        InvertBinaryTree_Recustive_dfs(root.Right);

        return root;
    }

    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the stack can have at most n
            n = number of nodes in the tree
    */
    public BTTreeNode InvertBinaryTree_Iterative_dfs(BTTreeNode root)
    {
        if (root == null)
            return null;

        Stack<BTTreeNode> stack = new Stack<BTTreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            BTTreeNode node = stack.Pop();

            // swap left and right
            (node.Left, node.Right) = (node.Right, node.Left);

            if (node.Left != null)
                stack.Push(node.Left);

            if (node.Right != null)
                stack.Push(node.Right);
        }

        return root;
    }
}
