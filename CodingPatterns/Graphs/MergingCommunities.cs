using Domain;

namespace CodingPatterns.Trees;

public class MergingCommunities
{
    UnionFind uf;

    public MergingCommunities(int n)
    {
        uf = new UnionFind(n);    
    }

    /*
        Time: O(n) UnionFind creates parent and size arrays both of which take O(n) time
        Space: O(n) since UnionFind maintains parent and size arrays
            n = number of communities
    */
    public void Connect(int x, int y)
    {
        this.uf.Union(x, y);
    }

    public int GetCommunitySize(int x)
    {
        return this.uf.GetSize(x);
    }
}
