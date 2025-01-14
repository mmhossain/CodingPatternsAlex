namespace Domain;

public class BTTreeNode
{
    public int Value { get; set; }
    public BTTreeNode Left { get; set; }
    public BTTreeNode Right { get; set; }

    public BTTreeNode(int val)
    {
        Value = val;
    }
}
