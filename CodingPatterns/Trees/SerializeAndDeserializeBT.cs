using Domain;

namespace CodingPatterns.Trees;

public class SerializeAndDeserializeBT
{
    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the call stack can have n nodes
            n = number of nodes in the tree
    */
    public string Serialize(BTTreeNode root)
    {
        List<string> serializedNums = [];
        preorder(root, serializedNums);

        return string.Join(",", serializedNums);
    }

    private void preorder(BTTreeNode node,  List<string> serializedNums)
    {
        if (node == null)
        {
            serializedNums.Add("#");
            return;
        }

        serializedNums.Add(node.Value.ToString());
        preorder(node.Left, serializedNums);
        preorder(node.Right, serializedNums);
    }

    /*
        Time: O(n)  since we need to vist all nodes
        Space: O(n) since the call stack can have n nodes
            n = number of nodes in the tree
    */
    public BTTreeNode Deserialize(string data)
    {
        List<string> values = [..data.Split(",")];
        int[] index = new int[1];

        return buildTree(values, index);
    }

    private BTTreeNode buildTree(List<string> values, int[] index)
    {
        if (index[0] >= values.Count)
            return null;

        if (!int.TryParse(values[index[0]], out int val))
        {
            index[0]++;
            return null;
        }

        index[0]++;

        BTTreeNode root = new BTTreeNode(val);
        root.Left = buildTree(values, index);
        root.Right = buildTree(values, index);

        return root;
    }
}
