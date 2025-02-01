namespace CodingPatterns.BinarySearch;

public class MatrixSearch
{
    /*
        Time: O(log mn)
        Space: O(1)
            m = number of rows in the matrix
            n = number of columns in the matrix
    */
    public bool FindInSortedMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int left = 0, right = (m * n) - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int r = mid / n;
            int c = mid % n;

            if (matrix[r][c] == target)
                return true;

            if (matrix[r][c] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
