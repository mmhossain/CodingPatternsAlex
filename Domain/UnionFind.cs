namespace Domain;

public class UnionFind
{
    private int[] parent;
    private int[] size;

    public UnionFind(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;

        size = new int[n];
        Array.Fill<int>(size, 1);
    }

    public int Find(int x)
    {
        if (x == parent[x])
            return x;

        parent[x] = Find(parent[x]);

        return parent[x];
    }

    public void Union(int x, int y)
    {
        int repX = Find(x);
        int repY = Find(y);

        if (repX != repY)
        {
            if (size[repX] > size[repY])
            {
                parent[repY] = repX;
                size[repX] += size[repY];
            }
            else
            {
                parent[repX] = repY;
                size[repY] += size[repX];
            }
        }
    }

    public int GetSize(int x)
    {
        return size[Find(x)];
    }
}
