namespace CodingPatterns.Trees;

public class LongestIncreasingPath
{
    /*
        Time: O(m x n) since we need to visit all cells of the matrix
        Space: O(m x n) the recursion stack can go upto m x n
            m = number of rows in the matrix
            n = number of columns in the matrix
    */
    public int LongestIncreasingPathLength(int[][] matrix)
    {
        if (matrix == null)
            return 0;

        (int dr, int dc)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        int rows = matrix.Length, cols = matrix[0].Length;
        int length = 0;

        int[][] memo = new int[rows][];
        for(int r = 0; r < rows; r++)
            memo[r] = new int[cols];

        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                length = Math.Max(length, dfs(r, c, matrix, memo, directions));

        return length;
    }

    private int dfs(int r, int c, int[][] matrix, int[][] memo, (int dr, int dc)[] directions)
    {
        if (memo[r][c] != 0)
            return memo[r][c];

        int maxPathLen = 1;
        foreach ((int dr, int dc) in directions)
        {
            int newR = r + dr;
            int newC = c + dc;

            if (isWithinBounds(newR, newC, matrix) && matrix[newR][newC] > matrix[r][c])
                maxPathLen = Math.Max(maxPathLen, 1 + dfs(newR, newC, matrix, memo, directions));
        }

        memo[r][c] = maxPathLen;

        return maxPathLen;
    }

    private bool isWithinBounds(int r, int c, int[][] matrix)
    {
        return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[0].Length;
    }
}
