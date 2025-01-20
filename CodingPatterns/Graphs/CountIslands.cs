namespace CodingPatterns.Trees;

public class CountIslands
{
    /*
        Time: O(m x n) since we need to visit all cells of the matrix
        Space: O(m x n) since the recursion stack can have up to (m x n) calls
            m = number of rows in the matrix
            n = number of columns in the matrix
    */
    public int CountNumberOfIslands(int[][] matrix)
    {
        if (matrix == null)
            return 0;

        (int dr, int dc)[] directions = [
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        ];

        int count = 0;

        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                if (matrix[r][c] == 1)
                {
                    dfs(r, c, matrix, directions);
                    count++;
                }
            }
        }

        return count;
    }

    private void dfs(int r, int c, int[][] matrix, (int dr, int dc)[] directions)
    {
        matrix[r][c] = -1;

        foreach ((int dr, int dc) in directions)
        {
            int newR = r + dr;
            int newC = c + dc;

            if (isWithinBounds(newR, newC, matrix) && matrix[newR][newC] == 1)
                dfs(newR, newC, matrix, directions);
        }
    }

    private bool isWithinBounds(int r, int c, int[][] matrix)
    {
        return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[0].Length;
    }
}
