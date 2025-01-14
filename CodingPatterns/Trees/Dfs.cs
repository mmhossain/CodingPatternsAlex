using Domain;

namespace CodingPatterns.Trees;

public class Dfs
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion stack can take upto O(n)
            n = number of nodes in the tree
    */
    public List<int> Dfs_Preorder(BTTreeNode root)
    {
        List<int> result = [];

        helper(root, result);

        return result;

        void helper(BTTreeNode root, List<int> result)
        {
            if (root == null)
                return;

            result.Add(root.Value);
            helper(root.Left, result);
            helper(root.Right, result);
        }
    }

    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion stack can take upto O(n)
            n = number of nodes in the tree
    */
    public List<int> Dfs_Inorder(BTTreeNode root)
    {
        List<int> result = [];

        helper(root, result);

        return result;

        void helper(BTTreeNode root, List<int> result)
        {
            if (root == null)
                return;

            helper(root.Left, result);
            result.Add(root.Value);
            helper(root.Right, result);
        }
    }

    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion stack can take upto O(n)
            n = number of nodes in the tree
    */
    public List<int> Dfs_Postorder(BTTreeNode root)
    {
        List<int> result = [];

        helper(root, result);

        return result;

        void helper(BTTreeNode root, List<int> result)
        {
            if (root == null)
                return;

            helper(root.Left, result);
            helper(root.Right, result);
            result.Add(root.Value);
        }
    }
}
