namespace CodingPatterns.Trees;

public class MatrixInfection
{
    /*
        Time: O(m x n) since we need to visit all cells of the matrix
        Space: O(m x n) since the queue can have up to (m x n) cells
            m = number of rows in the matrix
            n = number of columns in the matrix
    */
    public int CountNumberOfSeconds(int[][] matrix)
    {
        (int dr, int dc)[] directions = [
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        ];

        Queue<(int, int)> queue = [];
        int ones = 0, seconds = 0;

        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                if (matrix[r][c] == 1)
                    ones++;
                else if (matrix[r][c] == 2)
                    queue.Enqueue((r, c));
            }
        }

        while (queue.Count > 0 && ones > 0)
        {
            seconds++;
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                (int r, int c) = queue.Dequeue();

                foreach ((int dr, int dc) in directions)
                {
                    int newR = r + dr;
                    int newC = c + dc;

                    if (isWithinBounds(newR, newC, matrix) && matrix[newR][newC] == 1)
                    {
                        matrix[newR][newC] = 2;
                        ones--;
                        queue.Enqueue((newR, newC));
                    }
                }
            }
        }

        return ones == 0 ? seconds : -1;
    }

    private bool isWithinBounds(int r, int c, int[][] matrix)
    {
        return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[0].Length;
    }
}
