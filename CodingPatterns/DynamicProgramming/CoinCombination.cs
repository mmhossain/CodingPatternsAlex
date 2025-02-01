namespace CodingPatterns.DynamicProgramming;

public class CoinCombination
{
    /*
        Time: O(t x n) since we have at most target sub problems and we try all n coins for each target
        Space: O(t) the recursion stack can go upto t
            n = number of coins
            t = target
    */
    public int MinCoinCombination_TopDown(List<int> coins, int target)
    {
        int[] memo = new int[target + 1];
        Array.Fill<int>(memo, int.MaxValue);

        int result = topDownHelper(coins, target, memo);

        return result != int.MaxValue ? result : -1;
    }

    private int topDownHelper(List<int> coins, int target, int[] memo)
    {
        if (target == 0)
            return 0;

        if (memo[target] != int.MaxValue)
            return memo[target];

        int minCoins = int.MaxValue;
        foreach (int coin in coins)
        {
            if (coin <= target)
                minCoins = Math.Min(minCoins, 1 + topDownHelper(coins, target - coin, memo));
        }

        memo[target] = minCoins;

        return memo[target];
    }

    /*
        Time: O(t x n) since we have at most target sub problems and we try all n coins for each target
        Space: O(t) the dp array takes O(t) space
            n = number of coins
            t = target
    */
    public int MinCoinCombination_BottomUp(List<int> coins, int target)
    {
        int[] dp = new int[target + 1];
        Array.Fill<int>(dp, int.MaxValue);

        dp[0] = 0;

        for (int t = 1; t <= target; t++)
        {
            foreach (int coin in coins)
            {
                if (coin <= t)
                    dp[t] = Math.Min(dp[t], 1 + dp[t - coin]);
            }
        }

        return dp[target] != int.MaxValue ? dp[target] : -1;
    }
}