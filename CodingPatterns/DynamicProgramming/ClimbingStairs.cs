namespace CodingPatterns.DynamicProgramming;

public class ClimbingStairs
{
    /*
        Time: O(n) since we calculate only for n states
        Space: O(n) the recursion stack can go upto n
    */
    public int ClimbingStairs_TopDown(int n)
    {
        int[] memo = new int[n + 1];
        Array.Fill<int>(memo, -1);

        return topDownHelper(n, memo);
    }

    private int topDownHelper(int n, int[] memo)
    {
        if (n <= 2)
            return n;

        if (memo[n] != -1)
            return memo[n];

        memo[n] = topDownHelper(n - 1, memo) + topDownHelper(n - 2, memo);

        return memo[n];
    }

    /*
        Time: O(n) since we calculate only for n states
        Space: O(n) the dp array takes O(n) space
    */
    public int ClimbingStairs_BottomUp(int n)
    {
        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
            dp[i] = dp[i - 1] + dp[i - 2];

        return dp[n];
    }

    /*
        Time: O(n) since we calculate only for n states
        Space: O(1)
    */
    public int ClimbingStairs_BottomUp_Optimized(int n)
    {
        int prev = 2;
        int prevPrev = 1;

        for (int i = 3; i <= n; i++)
        {
            int current = prev + prevPrev;
            prevPrev = prev;
            prev = current;
        }

        return prev;
    }
}
