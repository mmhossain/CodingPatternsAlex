using Domain;

namespace CodingPatterns.Trees;

public class LowestCommonAncestor
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the recursion stack can have up to n nodes
            n = number of nodes in the tree
    */
    public BTTreeNode Lca(BTTreeNode root, BTTreeNode p, BTTreeNode q)
    {
        BTTreeNode[] result = new BTTreeNode[1];
        
        dfs(root, p, q, result);
        
        return result[0];
    }

    private bool dfs(BTTreeNode node, BTTreeNode p, BTTreeNode q, BTTreeNode[] result)
    {
        if (node == null)
            return false;

        int nodeIsPOrQ = (node == p || node == q) ? 1 : 0;
        int leftContainsPOrQ = dfs(node.Left, p, q, result) ? 1 : 0;
        int rightContainsPOrQ = dfs(node.Right, p, q, result) ? 1 : 0;

        if (nodeIsPOrQ + leftContainsPOrQ + rightContainsPOrQ == 2)
            result[0] = node;

        return nodeIsPOrQ == 1 || leftContainsPOrQ == 1 || rightContainsPOrQ == 1;
    }
}
